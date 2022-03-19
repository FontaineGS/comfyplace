using CV.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Agents.Animals;
using CV.Map;
using CV.Map.basicStruct;

using CV.Ai;
using CV.Ai.AnimalsAI;

namespace CV.World
{
    public class WorldGenerator
    {
        Random a = new Random();
        public CompleteWorld GenerateWorldTerrain()
        {
            var world = new CompleteWorld();
            var terrain = world.Terrain;
            var terrainbuilder = new TerrainBuilder();
            terrainbuilder.Init(terrain);
            return world;
        }

        public void Populate(CompleteWorld world)
        {
            Random rand = new Random();
            for (int i =0; i < 6; i++)
            {
                Tree a = new Tree
                {
                    Height = ((float)rand.NextDouble() * 10),
                    Location = GetRandomWorldLocation(world)
                };
                world.Agents.Add(a);
            }
            for (int i = 0; i < 1; i++)
            {
                Rabbit a = new Rabbit();
                a.Location = GetRandomWorldLocation(world);
                a.Speed = new SpeedVector();
                world.Agents.Add(a);


                RabbitAI ia = new RabbitAI(a);
                world.Ias.Add(ia);
            }

            for (int i = 0; i < 1; i++)
            {
                Fox a = new Fox();
                a.Location = GetRandomWorldLocation(world);
                a.Speed = new SpeedVector();
                world.Agents.Add(a);


                FoxAI ia = new FoxAI(a);
                world.Ias.Add(ia);
            }
        }

        public WorldLocation GetRandomWorldLocation(CompleteWorld world)
        {
            var location = new WorldLocation();

            var lenght = world.Terrain.SIZE;

           

            location.X = (float)a.NextDouble() * lenght;
            location.Y = (float)a.NextDouble() * lenght;
            location.Z = 0;// (float)a.NextDouble() * lenght;
            return location;
        }
    }
}
