using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Agents.Animals
{
    public abstract class Animal : MovingAgent
    {
        public bool IsAlive { get; } = true;

        public abstract int Meat { get; }
    }
}
