using AgentUtitilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorldUtilities
{
    public class CompleteWorld : World
    {

        public World GetWorldState(IAgent pov)
        {
            return _subjectiveWorld;
        }

        #region specific world

        World _subjectiveWorld = new World();

        #endregion

        #region specific 

        public int TickTime { get; set; } = 500; //en ms

        #endregion
    }
}
