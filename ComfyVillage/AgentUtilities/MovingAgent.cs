using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;

namespace AgentUtitilies
{
    public abstract class MovingAgent : IAgent
    {
        [Key]
        public Guid Id { get; set; }

        public MovingAgent()
        {
            Id = Guid.NewGuid();
        }

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


        public SpeedVector Speed { get; set; }

        public float currentVelocity { get; set; } = 1.0f;
        #endregion
    }
}
