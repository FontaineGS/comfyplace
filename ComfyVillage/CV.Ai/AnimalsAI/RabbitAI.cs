using System.Collections.Generic;
using System.Linq;
using CV.Agents;
using CV.Agents.Animals;
using CV.Ai.Modules;
using CV.Map.basicStruct;

namespace CV.Ai.AnimalsAI
{
    public class RabbitAI : AIBase<Rabbit>
    {
        public override void Compute(IEnumerable<IAgent> _agents)
        {
            var velocity = this.CalculateVelocity();

            Tree target = DetectionModule.NearestTree(_agents.Where(i => i.GetType() == typeof(Tree)).Select(j => j as Tree), _agent);
            if (target != null && _agent.Location.Distance(target.Location) > velocity)
            {
                _agent.Intent.MoveIntent = MoveModule.GetSpeedVector(_agent.Location, target.Location, velocity);
            }
            else
            {
                MoveModule.Stop(_agent);
            }
        }
        private float CalculateVelocity()
        {
            return _agent.MaxVelocity;
        }
        public RabbitAI(Rabbit r) : base()
        {
            this._agent = r;
        }
    }
}
