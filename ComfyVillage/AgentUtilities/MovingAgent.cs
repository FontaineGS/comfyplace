using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;

namespace AgentUtitilies
{
    public abstract class MovingAgent : IAgent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public abstract void SetObjective();

        public void Process()
        {

        }

        public WorldLocation Location
        {
            get; set;
        }

        #region moving element
        

        public WorldLocation objective = null;


        public SpeedVector Speed { get; set; } = new SpeedVector();

        public float currentVelocity { get; set; } = 5.0f;
        #endregion
    }
}
