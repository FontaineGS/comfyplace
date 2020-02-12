using System;
using System.Threading;
using System.Threading.Tasks;
using CV.World;

namespace LaunchingVillage
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldGenerator generator = new WorldGenerator();
            var World = generator.GenerateWorldTerrain();
            generator.Populate(World);
            WorldResolver resolver = new WorldResolver();

            RabbitWrapper wrapper = new RabbitWrapper();
            wrapper.Connect();

            JsonConverter jsonwriter = new JsonConverter();

           /* var task = new Task(() => WSServer.Setup(null));
            task.RunSynchronously();*/

            resolver.World = World;
            while (true)
            {

                resolver.Resolve();
                Console.WriteLine(World.Agents.Count);
                wrapper.WriteAll(jsonwriter.WriteToJson(World.Agents));
                wrapper.WriteAll(jsonwriter.WriteToJson(World.Terrain), "terrain_queue");
                Thread.Sleep(1000);
            }
        }
    }
}
