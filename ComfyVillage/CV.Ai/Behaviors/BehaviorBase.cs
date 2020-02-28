using System.Collections.Generic;
using CV.Ai.Objectives;

namespace CV.Ai.Behaviors
{
    internal abstract class BehaviorBase : IBehavior
    {
        private IObjective _objective;

        public IObjective Objective
        {
            get { return _objective; }
        }

        public abstract void Calculate();
    }
}