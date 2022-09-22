using RabbitMQ.Client;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace RabbitMQ.publisher
{
    public enum LogNames
    {
        Critical = 1,
        Error = 2,
        Warning = 3,
        Info = 4
    }
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            //channel.QueueDeclare("hello-queue", true, false, false);

            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);

            Dictionary<string, object> headers = new Dictionary<string, object>();

            headers.Add("format", "pdf");
            headers.Add("shape", "a4");

            var properties = channel.CreateBasicProperties();
            properties.Headers = headers;
            properties.Persistent = true;

            var product = new Product { Id = 1, Name = "Kalem", Price = 22 };
            var productJsonString = JsonSerializer.Serialize(product);


            channel.BasicPublish("header-exchange", string.Empty, properties, Encoding.UTF8.GetBytes(productJsonString));

            Console.WriteLine("Mesaj gönderilmiştir");

            Console.ReadLine();
        }
    }
}
