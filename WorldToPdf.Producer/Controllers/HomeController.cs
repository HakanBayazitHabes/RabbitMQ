using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorldToPdf.Producer.Models;

namespace WorldToPdf.Producer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ConnectionFactory connectionFactory)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult WordToPdfPage()
        {

            return View();
        }
        [HttpPost]
        public IActionResult WordToPdfPage(WordToPdf wordToPdf)
        {
            using (_connection = _connectionFactory.CreateConnection())
            {

                if (_channel is { IsOpen: true })
                {
                    return (IActionResult)_channel;
                }
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare("convert-exchange", ExchangeType.Direct, true, false, null);

                _channel.QueueDeclare(queue: "File", durable: true, exclusive: false, autoDelete: false, arguments: null);

                _channel.QueueBind("File", "convert-exchange", "WordToPdf");

                MessageWordToPdf messageWordToPdf = new MessageWordToPdf();

                using (MemoryStream ms = new MemoryStream())
                {
                    wordToPdf.WordFile.CopyTo(ms);
                    messageWordToPdf.WordByte = ms.ToArray();
                }

                messageWordToPdf.Email = wordToPdf.Email;
                messageWordToPdf.FileName = Path.GetFileNameWithoutExtension(wordToPdf.WordFile.FileName);

                var bodyString = JsonSerializer.Serialize(messageWordToPdf);

                var bodyByte = Encoding.UTF8.GetBytes(bodyString);

                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                _channel.BasicPublish(exchange: "convert-exchange", routingKey: "WordToPdf", basicProperties: properties, body: bodyByte);
                ViewBag.result = "Worl dosyanız pdf dosyasına dönüştürüldükten sonra size email olarak gönderilecektir.";
                return View();

            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
