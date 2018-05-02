using AgentUtitilies;
using DatabaseService.DbClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseService.DatabaseUtilities
{
    public class DbManager
    {

        public VillageContext villageContext { get; set; }

        public DbManager(VillageContext context)
        {
            villageContext = context;
        }

        public void DeleteTables()
        {
            var rabbits = villageContext.Agents;
            rabbits.RemoveRange(rabbits);

            var trees = villageContext.Trees;
            trees.RemoveRange(trees);
            villageContext.SaveChanges();
        }

        public void UpdateTable(IEnumerable<Rabbit> rabbitcollection)
        {
            foreach (Rabbit rabbit in rabbitcollection)
            {
                if (villageContext.Find(typeof(Rabbit), rabbit.Id) == null)
                {
                    villageContext.Agents.Add(rabbit);
                }
                else
                {
                    var entry = villageContext.Agents.SingleOrDefault(x => x.Id.Equals(rabbit.Id));
                    villageContext.Entry(entry).CurrentValues.SetValues(rabbit);
                }
            }
           
                villageContext.SaveChanges();
            
        }

        public void UpdateTable(IEnumerable<Tree> treecollection)
        {
            foreach (Tree tree in treecollection)
            {
                if (villageContext.Find(typeof(Tree), tree.Id) == null)
                {
                    villageContext.Trees.Add(tree);
                }
                else
                {
                    var entry = villageContext.Trees.SingleOrDefault(x => x.Id.Equals(tree.Id));
                    villageContext.Entry(entry).CurrentValues.SetValues(tree);
                }
            }

            villageContext.SaveChanges();
        }


    }
}
