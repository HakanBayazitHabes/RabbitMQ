using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace RabbitMQ.subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();
            //channel.QueueDeclare("hello-queue", true, false, false);
            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);

            //0=> herhangi bir boyuttaki değeri döndür
            //1=> Mesajlar kaçar adet gelsin
            //true => GelenMesaj/Subscriber ---- false => Gelen mesajları tek tek gönderir
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);

            var queueName = channel.QueueDeclare().QueueName;
            Dictionary<string, object> headers = new Dictionary<string, object>();

            headers.Add("format", "pdf");
            headers.Add("shape", "a4");
            headers.Add("x-match", "all");

            channel.QueueBind(queueName, "header-exchange", string.Empty,headers);
            //channel.BasicConsume("hello-queue", true, consumer);


            Console.WriteLine("Logları dinleniyor...");
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("Gelen Mesaj:" + message);
                Thread.Sleep(1500);
                File.AppendAllText("log-critical.txt", message + "\n");
                channel.BasicAck(e.DeliveryTag, false);
            };
            channel.BasicConsume(queue: queueName, //TODO: Consume edilecek kuyruk ismi
                    autoAck: false, //TODO: Gelen data doğru şekilde işlenirse kuyruktan silinir
                    consumer: consumer//TODO: Hangi consumer kullanılacak.
                    );
            Console.ReadLine();
        }

    }
}
