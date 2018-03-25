using DatabaseService.DbClass;
using System;
using System.Threading;

namespace DatabaseService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            RabbitListener listener = new RabbitListener();
            ModelFeeder feeder = new ModelFeeder();

            listener.Run(feeder.GetMessage);


            while(true)
            {
                Thread.Sleep(500);
            }
        }


    }
}
