using CV.Agents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CV.Agents.Intents;
using CV.Map.basicStruct;

namespace CV.Agents
{
    public class StaticAgent : IAgent
    {
        public WorldLocation Location { get; set; }

        [Key]
        public Guid Id { get; set; }

        public StaticAgent()
        {
            Id = Guid.NewGuid();
        }

        public Intent Intent { get; }
        
    }
}
