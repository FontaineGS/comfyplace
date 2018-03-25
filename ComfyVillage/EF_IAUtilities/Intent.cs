using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;

namespace IAManager
{
    public class Intent
    {
        public SpeedVector MoveIntent { get; set; } = null;

        public Behaviour CurrentBehavior { get; set; }
    }
}
