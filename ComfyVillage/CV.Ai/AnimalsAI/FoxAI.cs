using System;
using System.Collections.Generic;
using System.Text;
using CV.Agents;
using CV.Agents.Animals;

namespace CV.Ai.AnimalsAI
{
    public class FoxAI : AIBase<Fox>
    {
        public override void Compute(IEnumerable<IAgent> sworld)
        {
        }

        public FoxAI(Fox fox)
        {
            _agent = fox;
        }
    }
}
