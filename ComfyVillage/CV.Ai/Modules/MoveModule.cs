using System;
using System.Collections.Generic;
using System.Text;
using CV.Agents;
using CV.Map.basicStruct;

namespace CV.Ai.Modules
{
    internal static class MoveModule
    {
        internal static SpeedVector GetSpeedVector(WorldLocation origin, WorldLocation direction, float velocity)
        {
            var vector = direction - origin;

            var distance = direction.Distance(origin);
            var coeff = velocity / distance;

            vector = (vector * coeff);
            if (vector.Length > velocity)
            {
                vector = vector * (float)(vector.Length / coeff);
            }
            return new SpeedVector() { X = vector.X, Y = vector.Y, Z = vector.Z };
        }

        internal static void Stop(IMovingAgent agent)
        {
            agent.Speed.X = 0;
            agent.Speed.Y = 0;
            agent.Speed.Z = 0;
        }


        internal static SpeedVector Roam(WorldLocation agentLocation, float range, float velocity)
        {
            return GetSpeedVector(agentLocation, DetectionModule.GetRandomLocation(agentLocation, range), velocity);
        }
    }
}
