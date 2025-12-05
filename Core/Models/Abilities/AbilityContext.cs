using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abilities
{
    public class AbilityContext
    {
        public readonly Ability Ability;
        public readonly Champion Caster;

        // temporary workflow
        public readonly Unit Target;

        public AbilityContext(Ability ability, Champion caster, Unit target)
        {
            Ability = ability;
            Caster = caster;
            Target = target;
        }
    }
}
