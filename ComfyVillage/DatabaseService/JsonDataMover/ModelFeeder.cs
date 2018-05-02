using AgentUtitilies;
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

        public void GetMessage(string message)
        {
            JsonConverter converter = new JsonConverter();

            IEnumerable<IAgent> object_collection = converter.DeserializeJson(message);

            IEnumerable<Rabbit> rabbitcollection = object_collection.Where(i => i is Rabbit).Select(j => (Rabbit)j);

            IEnumerable<Tree> treecollection = object_collection.Where(i => i is Tree).Select(j => (Tree)j);

            //dbManager.DeleteTables();

            dbManager.UpdateTable(treecollection);

            dbManager.UpdateTable(rabbitcollection);

        }
    }
}
