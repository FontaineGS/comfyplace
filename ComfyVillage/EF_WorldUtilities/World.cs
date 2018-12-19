using AgentUtitilies;
using System.Collections.Generic;
using TerrainUtilities;
using IAUtilities;

namespace WorldUtilities
{
   public class World
    {

        #region Arrays

        private List<IAgent> _agents = new List<IAgent>();

        private List<IIa> _ias = new List<IIa>();

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


        public List<IIa> Ias
        {
            get
            {
                return _ias;
            }

            set
            {
                _ias = value;
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