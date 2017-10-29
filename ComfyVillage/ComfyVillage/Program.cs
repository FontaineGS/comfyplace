using AgentUtitilies;
using IAUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TerrainUtilities;
using WorldUtilities;

namespace ComfyVillage
{
    class Program
    {
        static void Main(string[] args)
        {

            WorldGenerator generator = new WorldGenerator();
            var world = generator.GenerateWorldTerrain();
            generator.Populate(world);

            var WorldResolver = new WorldResolver();
            WorldResolver.World = world;
            //Terrain initialisé


            List<IIa> ialist = new List<IIa>();
            foreach (Rabbit r in world.Agents.Where(i => i is Rabbit).Cast<Rabbit>())
            {
                ialist.Add(new RabbitIA(r));
            }

        }
    }
}
