using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Agents.Intents;
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
            Intent = new Intent();
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

        public float Energy { get; set; }
        public float Fatigue { get; set; }
        #endregion

        #region Intent
        public Intent Intent { get; }

        #endregion

    }
}
