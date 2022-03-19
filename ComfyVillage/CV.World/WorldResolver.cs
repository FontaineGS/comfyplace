using CV.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Map.basicStruct;
using CV.Ai;

namespace CV.World
{
    public class WorldResolver
    {
        public CompleteWorld World { get; set; } = null;

        public void Resolve()
        {
            World.Terrain.Erode();
        //    ComputeAI();
        //    Move();
        }

        private void ComputeAI()
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

            float _x = agent.Location.X + speed.X * tick;
            float _y = agent.Location.Y + speed.Y * tick;
            float _z = agent.Location.Z + speed.Z * tick;

            agent.Location.X = _x;
            agent.Location.Y = _y;
            agent.Location.Z = _z;


            //Comsumption
            agent.Energy -= agent.SpeedConsumption((float) agent.Speed.Length * tick * 1000);;
        }

        private void Move()
        {
            foreach (var agent in World.Agents.Where(i => i is MovingAgent).Cast<MovingAgent>())
            {

                Move(agent, agent.Intent.MoveIntent);
            }
        }

        #endregion
    }
}
