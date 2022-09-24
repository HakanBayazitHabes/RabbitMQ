using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Spire.Doc;
using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace WorldToPdf.Consumer
{
    class Program
    {

        public static bool EmailSend(string email, MemoryStream memoryStream, string fileName)
        {
            try
            {
                memoryStream.Position = 0;

                ContentType ct = new ContentType(MediaTypeNames.Application.Pdf);

                Attachment attach = new Attachment(memoryStream, ct);
                attach.ContentDisposition.FileName = $"{fileName}.pdf";

                MailMessage mailMessage = new MailMessage();

                SmtpClient smtpClient = new SmtpClient("smtp.yandex.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new System.Net.NetworkCredential("questionautomation@yandex.com", "topnjkmpmuqbgcce");

                mailMessage.From = new MailAddress("questionautomation@yandex.com");
                mailMessage.To.Add(email);

                mailMessage.Subject = $"Pdf Dosyası oluşturma | bosybosy.com";
                mailMessage.Body = "Pdf dosyanız ektedir.";
                mailMessage.Body += $"Sonuç : {email} adresine gönderilmiştir.";
                mailMessage.IsBodyHtml = true;

                mailMessage.Attachments.Add(attach);
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Sonuç : {email} adresine gönderilmiştir.");

                memoryStream.Close();
                memoryStream.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mai gönderim sırasında bir hata meydana geldi : {ex.InnerException}");
                return false;
            }
        }
        static void Main(string[] args)
        {
            bool result = false;
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("convert-exchange", ExchangeType.Direct, true, false, null);

                    channel.QueueBind(queue: "File", exchange: "convert-exchange", "WordToPdf");

                    channel.BasicQos(0, 1, false);

                    var consumer = new EventingBasicConsumer(channel);

                    channel.BasicConsume("File", false, consumer);


                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            Console.WriteLine("Kuyruktan bir mesaj alındı ve işleniyor.");

                            Document document = new Document();

                            string message = Encoding.UTF8.GetString(ea.Body.ToArray());

                            MessageWordToPdf messageWordToPdf = JsonSerializer.Deserialize<MessageWordToPdf>(message);

                            document.LoadFromStream(new MemoryStream(messageWordToPdf.WordByte), FileFormat.Docx2013);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                document.SaveToStream(ms, FileFormat.PDF);

                                result = EmailSend(messageWordToPdf.Email, ms, messageWordToPdf.FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hata meydana geldi:" + ex.Message);
                        }

                        if (result)
                        {
                            Console.WriteLine("Kuyruktan mesaj başarıyla işlendi");
                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                    };
                    Console.WriteLine("Çıkmak için tıklayınız.");
                    Console.ReadLine();
                }
            }

        }
    }
}

