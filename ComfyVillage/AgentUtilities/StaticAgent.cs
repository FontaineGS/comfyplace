using AgentUtitilies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TerrainUtilities.basicStruct;

namespace AgentUtilities
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
    }
}
