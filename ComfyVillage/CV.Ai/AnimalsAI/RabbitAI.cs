using System.Collections.Generic;
using System.Linq;
using CV.Agents;
using CV.Agents.Animals;
using CV.Map.basicStruct;

namespace CV.Ai.AnimalsAI
{
    public class RabbitAI : AIBase<Rabbit>
    {
        public override void Compute(IEnumerable<IAgent> _agents)
        {
            var velocity = this.CalculateVelocity();

            Tree target = NearestTree(_agents.Where(i => i.GetType() == typeof(Tree)).Select(j => j as Tree));
            if (target != null && _agent.Location.Distance(target.Location) > velocity)
            {
                _agent.Speed = getSpeedVector(_agent.Location, target.Location, velocity);
            }
            else
            {
                Stop();
            }
        }

        private Tree NearestTree(IEnumerable<Tree> trees)
        {
            Tree temp = null;
            foreach (Tree tree in trees)
            {
                if (temp == null)
                {
                    temp = tree;
                }
                if (_agent.Location.Distance(tree.Location) < _agent.Location.Distance(temp.Location))
                {
                    temp = tree;
                }
            }
            return temp;
        }

        private SpeedVector getSpeedVector(WorldLocation origin, WorldLocation direction, float velocity)
        {
            var vector = direction - origin;

            var distance = direction.Distance(origin);
            var coeff = velocity / distance;

            vector = (vector * coeff);
            if (vector.Length > velocity)
            {
                vector = vector * (float)(vector.Length / coeff);
            }
            return new SpeedVector() {X = vector.X, Y = vector.Y, Z = vector.Z};
        }

        private void Stop()
        {
            _agent.Speed.X = 0;
            _agent.Speed.Y = 0;
            _agent.Speed.Z = 0;
        }

        private float CalculateVelocity()
        {
            return _agent.MaxVelocity;
        }

        public RabbitAI(Rabbit r)
        {
            this._agent = r;
        }
    }
}
