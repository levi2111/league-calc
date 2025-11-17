using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Results
{
    public class BasicAttackResult : EventResult
    {
        public Unit Receiver;
        public BasicAttackResult(Unit caster, Unit receiver) : base(caster)
        {
            Receiver = receiver;
        }
    }
}
