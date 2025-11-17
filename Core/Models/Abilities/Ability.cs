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

        public int CurrentRank { get; private set; }
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
    }
}
