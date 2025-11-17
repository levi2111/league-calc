using Core.Models.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Results
{
    public class AbilityResult : EventResult
    {
        AbilityContext Context { get; set; }
        public AbilityResult(AbilityContext abilityContext) : base(abilityContext.Caster)
        {
            Context = abilityContext;
        }
    }
}
