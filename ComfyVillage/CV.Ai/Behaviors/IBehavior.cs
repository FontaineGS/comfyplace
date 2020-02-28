using System;
using System.Collections.Generic;
using System.Text;
using CV.Ai.Objectives;

namespace CV.Ai.Behaviors
{
    interface IBehavior
    {
        IObjective Objective { get; }

        void Calculate();
    }
}
