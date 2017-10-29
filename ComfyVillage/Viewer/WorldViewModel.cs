using AgentUtitilies;
using Helper;
using IAUtilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldUtilities;

namespace Viewer
{
    public class WorldViewModel
    {

        public ObservableCollection<IIa> IAList
        {
            get; set;
        } = new ObservableCollection<IIa>();

        public CompleteWorld World { get; set; }

        private WorldResolver resolver = new WorldResolver();

        private Scheduler _scheduler = new Scheduler();


        public void InitComponent()
        {
            WorldGenerator generator = new WorldGenerator();
            var world = generator.GenerateWorldTerrain();
            generator.Populate(world);
            
            resolver.World = world;
            World = world;
            //Terrain initialisé


            
            foreach (Rabbit r in world.Agents.Where(i => i is Rabbit).Cast<Rabbit>())
            {
                IAList.Add(new RabbitIA(r));
            }
            StartScheduler();
        }


        private void WorldCompute()
        {
            #region IA 

            foreach (RabbitIA r in IAList)
            {
                r.Compute(World);
            }

            #endregion
            resolver.Resolve();
        }

        private void StartScheduler()
        {
            _scheduler.Init(WorldCompute, 500);
            _scheduler.Start();
        }
    }
}

