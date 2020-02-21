using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Map.basicStruct;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CV.Agents
{
    public class Human : MovingAgent
    {
        public WorldLocation Location
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override float MaxVelocity { get; }
        public override Func<float, float> SpeedConsumption { get; }

        public void Process()
        {

        }
    }
}
