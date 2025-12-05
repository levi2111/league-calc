using Core.Interfaces;
using Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abilities
{
    public class Ability
    {
        private BaseAbility _baseAbility;

        public int CurrentRank { get; set; }
        public double Cooldown { get; private set; }
        public DateTime? LastUsed { get; private set; }
        public TimeSpan CurrentCooldown
        {
            get
            {
                // hasn't been used yet
                if (LastUsed == null) return TimeSpan.FromSeconds(0);

                // has been used but not on cooldown anymore
                else if (DateTime.Now - (DateTime)LastUsed >= TimeSpan.FromSeconds(Cooldown))
                {
                    return TimeSpan.FromSeconds(0);
                }
                else return TimeSpan.FromSeconds(Cooldown) - (DateTime.Now - (DateTime)LastUsed);
            }
        }
        public bool OnCooldown { get
            {
                if (CurrentCooldown > TimeSpan.FromSeconds(0)) return true;
                else return false;
            } 
        }
        public Ability(BaseAbility baseAbility)
        {
            _baseAbility = baseAbility;
            CurrentRank = -1;
        }

        public AbilityResult Use(AbilityContext abilityContext, AbilityInput abilityInput)
        {
            AbilityResult abilityResult = new(abilityContext);
            return abilityResult;
        }

        public void UpdateCooldown(float abilityHaste)
        {
            if (CurrentRank < 0) return;

            Cooldown = _baseAbility.Cooldown[CurrentRank] * 100 / (100 + abilityHaste);
        }

        public void RankUp()
        {
            if (CurrentRank < _baseAbility.MaxRank) CurrentRank++;
        }

        public void ResetRank()
        {
            CurrentRank = -1;
        }

        // used for testing
        public Damage TestUse(Champion caster, Unit receiver)
        {
            int rank = 4;
            if (_baseAbility.UltimateAbility) rank = 2;
            double baseDmg = _baseAbility.BaseDamage[rank];

            double scalingDmg = 0;

            // "AD" is needed for total AD here, not TotalAD
            foreach (KeyValuePair<string, double[]> scaling in _baseAbility.Scalings)
            {
                scalingDmg += scaling.Value[rank] * caster.Stats[scaling.Key];
            }

            double totalDmg = baseDmg + scalingDmg;

            return new Damage(totalDmg, _baseAbility.DamageType, caster, receiver);
        }
    }
}
