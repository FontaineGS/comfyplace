using DatabaseService.DatabaseUtilities;
using DatabaseService.DbClass;
using System;
using System.Threading;
using System.Threading.Tasks;

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

                var agent_task = new Task(() => listener.Run(feeder.GetAgentMessage, "agent_queue"));
               var terrain_task = new Task(() =>listener.Run(feeder.GetTerrainMessage, "terrain_queue"));
                agent_task.Start();
            terrain_task.Start();

                while (true)
                {
                    Thread.Sleep(500);
                }
            }
        }


    }
}
