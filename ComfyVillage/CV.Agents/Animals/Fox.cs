using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Agents.Animals
{
    public class Fox : Animal
    {
        public override float MaxVelocity { get; } = 1.5f;
        public override Func<float, float> SpeedConsumption { get; } = (float speed) => { return speed; };
        public override int Energy { get; }
        public override int Fatigue { get; }
        public override int Meat { get; } = 150;
    }
}
