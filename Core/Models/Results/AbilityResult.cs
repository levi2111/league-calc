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
        public AbilityContext Context { get; set; }

        // testing purposes, should be possible to have multiple targets and multiple damage outputs
        public Damage Damage;
        public AbilityResult(AbilityContext abilityContext) : base(abilityContext.Caster)
        {
            Context = abilityContext;
            Champion caster = abilityContext.Caster;
            Unit target = abilityContext.Target;
            Ability ability = abilityContext.Ability;

            Damage = abilityContext.Ability.TestUse(caster, target);
        }
    }
}
