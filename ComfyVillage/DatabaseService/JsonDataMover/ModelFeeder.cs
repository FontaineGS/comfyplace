using AgentUtitilies;
using TerrainUtilities;
using DatabaseService.DatabaseUtilities;
using DatabaseService.DbClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseService
{
    public class ModelFeeder
    {

        public DbManager dbManager { get; set; }

        public ModelFeeder(DbManager dbmanager)
        {
            dbManager = dbmanager;
        }

        public void GetAgentMessage(string message)
        {
            JsonConverter converter = new JsonConverter();

            IEnumerable<IAgent> object_collection = converter.DeserializeJson(message, typeof(IEnumerable<IAgent>)) as IEnumerable<IAgent>;

            IEnumerable<Rabbit> rabbitcollection = object_collection.Where(i => i is Rabbit).Select(j => (Rabbit)j);

            IEnumerable<Tree> treecollection = object_collection.Where(i => i is Tree).Select(j => (Tree)j);

            //dbManager.DeleteTables();

            dbManager.UpdateTable(treecollection);

            dbManager.UpdateTable(rabbitcollection);

        }

        public void GetTerrainMessage(string message)
        {
            JsonConverter converter = new JsonConverter();

            Terrain terrain = converter.DeserializeJson(message, typeof(Terrain)) as Terrain;

            if (terrain == null)
                Console.WriteLine("help" + message);
            else
                Console.WriteLine(terrain.SIZE);
            dbManager.UpdateTable(terrain);

        }
    }
}
