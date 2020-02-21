using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV.Agents;
using CV.Agents.Intents;

namespace CV.Ai
{
    public interface IIa
    {
        int Id { get; set; }
        void Compute(IEnumerable<IAgent> sworld);
    }
}
