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

        public  void WriteAll(string message)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "agent_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "agent_queue",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("objets envoyés");
            }
            
        }
    }
}
