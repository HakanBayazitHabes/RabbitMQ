using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            //0=> herhangi bir boyuttaki değeri döndür
            //1=> Mesajlar kaçar adet gelsin
            //true => GelenMesaj/Subscriber ---- false => Gelen mesajları tek tek gönderir
            channel.BasicQos(0, 1, false);

            //channel.QueueDeclare("hello-queue", true, false, false);
            channel.QueueDeclare(queue: "hello-queue",
                    durable: true, //Data fiziksel olarak mı yoksa memoryde mi tutulsun
                    exclusive: false, //Başka connectionlarda bu kuyruğa ulaşabilsin mi
                    autoDelete: false, //Eğer kuyruktaki son mesaj ulaştığında kuyruğun silinmesini istiyorsak kullanılır.
                    arguments: null//Exchangelere verilecek olan parametreler tanımlamak için kullanılır.
                    );
            var consumer = new EventingBasicConsumer(channel);

            //channel.BasicConsume("hello-queue", true, consumer);
            channel.BasicConsume(queue: "hello-queue", //TODO: Consume edilecek kuyruk ismi
                    autoAck: false, //TODO: Gelen data doğru şekilde işlenirse kuyruktan silinir
                    consumer: consumer//TODO: Hangi consumer kullanılacak.
                    );
            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("Gelen Mesaj:" + message);

                channel.BasicAck(e.DeliveryTag, false);
            };
            Console.ReadLine();
        }

    }
}
