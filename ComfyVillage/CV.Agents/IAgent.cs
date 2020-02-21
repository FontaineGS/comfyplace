using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Agents.Intents;
using CV.Map.basicStruct;

namespace CV.Agents
{
    public interface IAgent
    { 
        WorldLocation Location { get;}
        Intent Intent { get; }
    }
}
