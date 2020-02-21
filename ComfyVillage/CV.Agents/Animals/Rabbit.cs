using System;
using System.Runtime.CompilerServices;
using CV.Map.basicStruct;

namespace CV.Agents.Animals
{
    public class Rabbit : Animal
    {
        public override float MaxVelocity { get; } = 1.0f;
        public override Func<float, float> SpeedConsumption { get; } = (float speed) => { return speed; };
        public override int Meat { get; } = 100;
        public Rabbit()
        {
            Fatigue = 0;
            Energy = 100;
        }
    }
}

