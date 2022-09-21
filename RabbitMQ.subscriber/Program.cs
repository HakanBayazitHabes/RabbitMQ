using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
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

            var randomQueueName = channel.QueueDeclare().QueueName;


            channel.QueueBind(randomQueueName, "logs-fanout", "", null);


            //0=> herhangi bir boyuttaki değeri döndür
            //1=> Mesajlar kaçar adet gelsin
            //true => GelenMesaj/Subscriber ---- false => Gelen mesajları tek tek gönderir
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            //channel.BasicConsume("hello-queue", true, consumer);
            channel.BasicConsume(queue: randomQueueName, //TODO: Consume edilecek kuyruk ismi
                    autoAck: false, //TODO: Gelen data doğru şekilde işlenirse kuyruktan silinir
                    consumer: consumer//TODO: Hangi consumer kullanılacak.
                    );

            Console.WriteLine("Logları dinleniyor...");
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("Gelen Mesaj:" + message);
                Thread.Sleep(1500);
                channel.BasicAck(e.DeliveryTag, false);
            };

            Console.ReadLine();
        }

    }
}
