using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Map.basicStruct;

namespace CV.Agents.Intents
{
    public class Intent
    {
        public SpeedVector MoveIntent { get; set; } = null;

        public Behaviour CurrentBehavior { get; set; }
    }
}
