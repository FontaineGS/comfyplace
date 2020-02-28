using System;
using System.Collections.Generic;
using System.Text;
using CV.Map.basicStruct;

namespace CV.Ai.Objectives
{
    internal interface IObjective
    {
         WorldLocation Location { get; set; }
         bool IsComplete { get; set; }
         int Score { get;}
         void Refresh();
    }
}
