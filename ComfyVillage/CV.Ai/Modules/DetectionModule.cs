using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using CV.Agents;
using CV.Map.basicStruct;

namespace CV.Ai.Modules
{
    internal static class DetectionModule
    {
        internal static Tree NearestTree(IEnumerable<Tree> trees, IAgent agent)
        {
            Tree temp = null;
            foreach (Tree tree in trees)
            {
                if (temp == null)
                {
                    temp = tree;
                }
                if (agent.Location.Distance(tree.Location) < agent.Location.Distance(temp.Location))
                {
                    temp = tree;
                }
            }
            return temp;
        }

        internal static WorldLocation GetRandomLocation(WorldLocation location, float range)
        {
            WorldLocation result = new WorldLocation();
            var rand = new Random();
            var randX = (float)rand.NextDouble() * 2 * range - range;
            var randY = (float)rand.NextDouble() * 2 * range - range;
            result.X = location.X + randX;
            result.Y = location.Y + randY;
            return result;
        }
    }
}
