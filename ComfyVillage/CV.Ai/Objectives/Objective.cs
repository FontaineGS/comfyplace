using CV.Map.basicStruct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CV.Agents.Intents;

namespace CV.Ai.Objectives
{
    internal class Objective : IObjective
    {
        public WorldLocation Location { get; set; }

        public bool IsComplete { get; set; }

        public virtual int Score { get; set; }
        public Atittude Attitude { get; set; }

        public virtual void Refresh()
        {
        }
    

}
}
