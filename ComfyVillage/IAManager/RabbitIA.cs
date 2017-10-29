using AgentUtitilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainUtilities.basicStruct;
using WorldUtilities;

namespace IAUtilities
{
    public class RabbitIA : IIa
    {
        public void Compute(World sworld)
        {
            if (_rabbit != null)
            {
                Tree target = NearestTree(sworld);
                if (target != null)
                    MoveTo(target.Location);
            }

        }

        private Tree NearestTree(World sworld)
        {
            Tree temp = null;
            foreach (Tree tree in sworld.Agents.Where(i => i is Tree).Cast<Tree>())
            {
                if (temp == null)
                {
                    temp = tree;
                }
                if (_rabbit.Location.Distance(tree.Location) < _rabbit.Location.Distance(temp.Location))
                {
                    temp = tree;
                }
            }
            return temp;
        }

        private void MoveTo(WorldLocation direction)
        {
            var speed = _rabbit.currentVelocity;
            var vector = direction - _rabbit.Location;

            var distance = direction.Distance(_rabbit.Location);
            var coeff = speed / distance;

            vector = (vector / coeff);

            _rabbit.Speed.X = vector.X;
            _rabbit.Speed.Y = vector.Y;
            _rabbit.Speed.Z = vector.Z;
        }


        private Rabbit _rabbit = null;

        public RabbitIA(Rabbit r)
        {
            this._rabbit = r;
        }
    }
}
