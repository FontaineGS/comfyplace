using AgentUtitilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;

namespace WorldUtilities
{
    public class WorldResolver
    { 


        public CompleteWorld World { get; set; } = null;

        public void Resolve()
        {

            Move();
        }

        #region IA

    

        #endregion

        #region moving
        private void Move(MovingAgent agent, SpeedVector speed)
        {
            float  tick = World.TickTime /1000; //en secondes

            float _x = agent.Location.X + speed.X * tick;
            float _y = agent.Location.Y + speed.Y * tick;
            float _z = agent.Location.Z + speed.Z * tick;

            agent.Location.X = _x;
            agent.Location.Y = _y;
            agent.Location.Z = _z;
        }

        private void Move()
        {
            foreach(var agent in World.Agents.Where(i => i is MovingAgent).Cast<MovingAgent>())
            {
                Move(agent, agent.Speed);
            }
        }

        #endregion
    }
}
