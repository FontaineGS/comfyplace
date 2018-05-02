using System;
using System.Threading;
using WorldUtilities;

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

            resolver.World = World;
            while (true)
            {

                Thread.Sleep(500);
                resolver.Resolve();
                Console.WriteLine(World.Agents.Count);
                wrapper.WriteAll(jsonwriter.WriteToJson(World.Agents));


            }
        }
    }
}
