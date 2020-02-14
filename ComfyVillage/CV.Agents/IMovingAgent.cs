using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Agents
{
    interface IMovingAgent
    {
        float MaxVelocity { get; }

        Func<float, float> SpeedConsumption { get; }
    }
}
