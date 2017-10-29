using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;

namespace AgentUtitilies
{
    public abstract class MovingAgent : IAgent
    {
        public abstract void SetObjective();

        public void Process()
        {

        }

        public WorldLocation Location
        {
            get; set;
        }

        #region moving element
        

        public WorldLocation objective = null;


        public SpeedVector Speed { get; set; } = new SpeedVector();

        public float currentVelocity { get; set; } = 5.0f;
        #endregion
    }
}
