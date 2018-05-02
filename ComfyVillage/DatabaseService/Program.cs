using DatabaseService.DatabaseUtilities;
using DatabaseService.DbClass;
using System;
using System.Threading;

namespace DatabaseService
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var villagecontext = new VillageContext())
            {
                Console.WriteLine("Hello World!");

                RabbitListener listener = new RabbitListener();

                DbManager dbmanager = new DbManager(villagecontext);

                ModelFeeder feeder = new ModelFeeder(dbmanager);

                listener.Run(feeder.GetMessage);


                while (true)
                {
                    Thread.Sleep(500);
                }
            }
        }


    }
}
