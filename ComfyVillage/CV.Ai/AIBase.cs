using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Resources;
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
            _agent.Intent.CurrentBehavior = CurrentObjective.Attitude;
        }

        protected virtual void Decide()
        {
            foreach (var behavior in Behaviors)
            {
                behavior.Calculate();
            }

            var objectives = Behaviors.Select(b => b.Objective).Where(o => o != null).Max(ob => ob.Score);

        }

        protected virtual void Detect()
        {
        }

        protected TAgent _agent;

        internal IEnumerable<IBehavior> Behaviors;

        internal IObjective CurrentObjective = null;

    }
}
