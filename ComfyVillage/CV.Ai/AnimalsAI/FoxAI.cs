using System;
using System.Collections.Generic;
using System.Text;
using CV.Agents;
using CV.Agents.Animals;
using CV.Ai.Modules;

namespace CV.Ai.AnimalsAI
{
    public class FoxAI : AIBase<Fox>
    {
        public override void Compute(IEnumerable<IAgent> sworld)
        {
            _agent.Intent.MoveIntent = MoveModule.Roam(_agent.Location, 10, _agent.MaxVelocity);
            
        }

        public FoxAI(Fox fox) : base()
        {
            _agent = fox;
        }
    }
}
