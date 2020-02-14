using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Map.basicStruct;

namespace CV.Agents
{
    public abstract class MovingAgent : IAgent, IMovingAgent
    {
        [Key]
        public Guid Id { get; set; }

        protected MovingAgent()
        {
            Id = Guid.NewGuid();
        }

        public WorldLocation Location
        {
            get; set;
        }

        #region moving element

        public SpeedVector Speed { get; set; }
        public  abstract float MaxVelocity { get; }
        public abstract Func<float, float> SpeedConsumption { get; }
        #endregion

        #region ressources

        public abstract int Energy { get; }
        public abstract int Fatigue { get; }
        #endregion


    }
}
