using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CV.Agents;
using CV.Agents.Intents;
using CV.Ai.Behaviors;
using CV.Ai.Modules;
using CV.Ai.Objectives;

namespace CV.Ai
{
    public abstract class AIBase<TAgent> : IIa where TAgent : IAgent
    {
        protected AIBase()
        {
            Behaviors = new List<IBehavior>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual void Compute(IEnumerable<IAgent> sworld)
        {
            Detect();
            Decide();
            Act();
        }

        protected virtual void Act()
        {
            throw new NotImplementedException();
        }

        protected virtual void Decide()
        {
            throw new NotImplementedException();
        }

        protected virtual void Detect()
        {
            throw new NotImplementedException();
        }

        protected TAgent _agent;

        internal IEnumerable<IBehavior> Behaviors;

        internal IObjective CurrentObjective = null;

    }
}
