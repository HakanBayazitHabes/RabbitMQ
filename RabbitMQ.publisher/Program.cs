using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace RabbitMQ.publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            //channel.QueueDeclare("hello-queue", true, false, false);

            channel.ExchangeDeclare("logs-fanout", durable: true, type: ExchangeType.Fanout);

            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {
                string message = $"Log {x}";
                var messageBody = Encoding.UTF8.GetBytes(message);
                //channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
                //Queue ya atmak için kullanılır.
                channel.BasicPublish(exchange: "logs-fanout",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                    routingKey: "", //Hangi queue ya atanacak.
                    body: messageBody//Mesajun içeriği
                    );
                Thread.Sleep(1500);
                Console.WriteLine($"Mesaj Gönderilmiştir : {message}");

            });



            Console.ReadLine();
        }
    }
}
