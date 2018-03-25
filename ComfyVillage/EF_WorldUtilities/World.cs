using AgentUtitilies;
using System.Collections.Generic;
using TerrainUtilities;

namespace WorldUtilities
{
    public class World
    {

        #region Arrays

        private List<IAgent> _agents = new List<IAgent>();

        Terrain _terrain = new Terrain();

        public List<IAgent> Agents
        {
            get
            {
                return _agents;
            }

            set
            {
                _agents = value;
            }
        }

        public Terrain Terrain
        {
            get
            {
                return _terrain;
            }

            set
            {
                _terrain = value;
            }
        }

        #endregion
    }
}