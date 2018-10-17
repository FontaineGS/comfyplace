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
            return this as World;
        }

        #region specific world


        #endregion

        #region specific 

        public static int TickTime  = 500; //en ms

        #endregion
    }
}
