using AgentUtitilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;
using IAUtilities;

namespace WorldUtilities
{
    public class WorldResolver
    {


        public CompleteWorld World { get; set; } = null;

        public void Resolve()
        {
            ComputeIA();
            Move();
        }

        private void ComputeIA()
        {
            foreach(var IIA in World.Ias)
            {
                IIA.Compute(World.Agents);
            }
        }

        #region moving
        private void Move(MovingAgent agent, SpeedVector speed)
        {
            if (speed == null)
                return;
            float tick = (float)CompleteWorld.TickTime / 1000; //en secondes


            Console.WriteLine(" " + tick);
            Console.WriteLine(speed.X + " " +speed.Y);

            Console.WriteLine(agent.Location.X + " " +agent.Location.Y);
            float _x = agent.Location.X + speed.X * tick;
            float _y = agent.Location.Y + speed.Y * tick;
            float _z = agent.Location.Z + speed.Z * tick;

            agent.Location.X = _x;
            agent.Location.Y = _y;
            agent.Location.Z = _z;

            Console.WriteLine(_x + " " +_y);
        }

        private void Move()
        {
            foreach (var agent in World.Agents.Where(i => i is MovingAgent).Cast<MovingAgent>())
            {
                Move(agent, agent.Speed);
            }
        }

        #endregion
    }
}
