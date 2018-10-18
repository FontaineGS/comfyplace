using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseService
{
    public class RabbitListener
    {
        public void Run(Action<string> getMessage, string queue)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("message reçu" + queue);
                    getMessage(message);
                    
                };
                channel.BasicConsume(queue: queue,
                                     autoAck: true,
                                     consumer: consumer);

                
                while(true)
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}
