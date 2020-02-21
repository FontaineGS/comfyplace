using System;
using System.Collections.Generic;
using System.Text;
using CV.Map.basicStruct;

namespace CV.Agents
{
    public interface IMovingAgent
    {
        float MaxVelocity { get; }

        Func<float, float> SpeedConsumption { get; }

        SpeedVector Speed { get; set; }
    }
}
