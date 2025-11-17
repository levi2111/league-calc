using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Results
{
    public abstract class EventResult
    {
        public Unit Caster { get; }
        public EventResult(Unit caster)
        {
            Caster = caster;
        }
    }
}
