using AgentUtitilies;
using DatabaseService.DbClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseService
{
    public class ModelFeeder
    {
        public VillageContext villageContext { get; set; }


        public ModelFeeder(VillageContext context)
        {
            villageContext = context;
        }
        public ModelFeeder()
        {
        }

        public void GetMessage(string message)
        {
            JsonConverter converter = new JsonConverter();

            IEnumerable<IAgent> object_collection = converter.DeserializeJson(message);

            IEnumerable<Rabbit> rabbitcollection = object_collection.Where(i => i is Rabbit).Select(j => (Rabbit)j);

            IEnumerable<Tree> treecollection = object_collection.Where(i => i is Tree).Select(j => (Tree)j);

            villageContext.Agents.AddRange(rabbitcollection);

            villageContext.Trees.AddRange(treecollection);
        }
    }
}
