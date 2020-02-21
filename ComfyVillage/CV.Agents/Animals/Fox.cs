using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Agents.Animals
{
    public class Fox : Animal
    {
        public override float MaxVelocity { get; } = 50f;
        public override Func<float, float> SpeedConsumption { get; } = (float speed) => { return speed; };
        public override int Meat { get; } = 150;

        public Fox()
        {
            Fatigue = 0;
            Energy = 100;
        }
    }
}
