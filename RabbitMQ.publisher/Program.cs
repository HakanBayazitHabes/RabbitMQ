using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;
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

            channel.ExchangeDeclare("logs-topic", durable: true, type: ExchangeType.Topic);

            Random rnd = new Random();
            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {
                //channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
                LogNames log1 = (LogNames)rnd.Next(1, 5);
                LogNames log2 = (LogNames)rnd.Next(1, 5);
                LogNames log3 = (LogNames)rnd.Next(1, 5);
                var routeKey = $"{log1}.{log2}.{log3}";
                string message = $"log-type: {log1}-{log2}-{log3}";
                var messageBody = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "logs-topic",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                    routingKey: routeKey, //Hangi queue ya atanacak.
                    body: messageBody//Mesajun içeriği
                    );

                Console.WriteLine($"Mesaj Gönderilmiştir : {message}");

            });



            Console.ReadLine();
        }
    }
}
