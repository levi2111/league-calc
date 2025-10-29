using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Ability
    {
        private BaseAbility _baseAbility;

        public Champion Champion { get; set; }
        public int CurrentRank { get; private set; }
        public double Cooldown { get; private set; }
        public DateTime? LastUsed { get; set; }
        public TimeSpan CurrentCooldown
        {
            get
            {
                // hasn't been used yet
                if (LastUsed == null) return TimeSpan.FromSeconds(0);

                // has been used but not on cooldown anymore
                else if ((DateTime.Now - (DateTime)LastUsed) >= TimeSpan.FromSeconds(Cooldown))
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
        public Ability(BaseAbility baseAbility, Champion champion)
        {
            _baseAbility = baseAbility;
            Champion = champion;
            CurrentRank = -1;
        }

        public void UpdateCooldown()
        {
            if (CurrentRank < 0) return;

            Cooldown = _baseAbility.Cooldown[CurrentRank] * 100 / (100 + Champion.CDR);
        }
    }
}
