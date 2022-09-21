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

            channel.ExchangeDeclare("logs-direct", durable: true, type: ExchangeType.Direct);

            Enum.GetNames(typeof(LogNames)).ToList().ForEach(x =>
            {
                var routeKey = $"route-{x}";
                var queueName = $"direct-queue-{x}";
                channel.QueueDeclare(queueName, true, false, false);
                channel.QueueBind(queueName, "logs-direct", routeKey, null);
            });

            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {
                LogNames log = (LogNames)new Random().Next(1, 4);
                string message = $"log-type: {log}";
                var messageBody = Encoding.UTF8.GetBytes(message);
                //channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
                //Queue ya atmak için kullanılır.
                var routeKey = $"route-{log}";
                channel.BasicPublish(exchange: "logs-direct",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                    routingKey: routeKey, //Hangi queue ya atanacak.
                    body: messageBody//Mesajun içeriği
                    );
                
                Console.WriteLine($"Mesaj Gönderilmiştir : {message}");

            });



            Console.ReadLine();
        }
    }
}
