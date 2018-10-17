using AgentUtitilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities;
using TerrainUtilities.basicStruct;

using IAUtilities;

namespace WorldUtilities
{
    public class WorldGenerator
    {
        Random a = new Random();
        public CompleteWorld GenerateWorldTerrain()
        {
            var world = new CompleteWorld();
            var terrain = world.Terrain;
            terrain.Init();
            var terrainbuilder = new TerrainBuilder();
            terrainbuilder.Init(terrain);
            terrainbuilder.DiamondAlgoritm();
            return world;
        }

        public void Populate(CompleteWorld world)
        {
            Random rand = new Random();
            for (int i =0; i < 1; i++)
            {
                Tree a = new Tree
                {
                    Height = ((float)rand.NextDouble() * 10),
                    Location = GetRandomWorldLocation(world)
                };
                world.Agents.Add(a);
            }
            for (int i = 0; i < 10; i++)
            {
                Rabbit a = new Rabbit();
                a.Location = GetRandomWorldLocation(world);
                a.Speed = new SpeedVector();
                world.Agents.Add(a);


                RabbitIA ia = new RabbitIA(a);
                world.Ias.Add(ia);
            }
        }

        public WorldLocation GetRandomWorldLocation(CompleteWorld world)
        {
            var location = new WorldLocation();

            var lenght = world.Terrain.HeightMap.Length;

           

            location.X = (float)a.NextDouble() * lenght;
            location.Y = (float)a.NextDouble() * lenght;
            location.Z = 0;// (float)a.NextDouble() * lenght;
            return location;
        }
    }
}
