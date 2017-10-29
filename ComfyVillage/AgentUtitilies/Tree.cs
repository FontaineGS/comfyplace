using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;

namespace AgentUtitilies
{
    public class Tree : IAgent
    {
        public float Height;

        public WorldLocation Location
        {
            get; set;
        }

    }
}
