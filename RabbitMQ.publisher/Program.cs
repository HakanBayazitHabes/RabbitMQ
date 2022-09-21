using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

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
            channel.QueueDeclare(queue: "hello-queue",
                    durable: true, //Data fiziksel olarak mı yoksa memoryde mi tutulsun
                    exclusive: false, //Başka connectionlarda bu kuyruğa ulaşabilsin mi
                    autoDelete: false, //Eğer kuyruktaki son mesaj ulaştığında kuyruğun silinmesini istiyorsak kullanılır.
                    arguments: null//Exchangelere verilecek olan parametreler tanımlamak için kullanılır.
                    );
            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {
                string message = $"Message {x}";
                var messageBody = Encoding.UTF8.GetBytes(message);
                //channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
                //Queue ya atmak için kullanılır.
                channel.BasicPublish(exchange: "",//mesajın alınıp bir veya birden fazla queue ya konmasını sağlıyor.
                    routingKey: "hello-queue", //Hangi queue ya atanacak.
                    body: messageBody//Mesajun içeriği
                    );
                Console.WriteLine($"Mesaj Gönderilmiştir : {message}");

            });

            

            Console.ReadLine();
        }
    }
}
