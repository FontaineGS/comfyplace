using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchingVillage
{
    public class RabbitWrapper
    {


        ConnectionFactory factory = null;
        public  void Connect()
        {
           factory = new ConnectionFactory() { HostName = "localhost" };
            

        }

        public  void WriteAll(string message, string queue_name = "agent_queue")
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue_name,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queue_name,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("objets envoyés");
            }
            
        }


    }
}
