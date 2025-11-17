using Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Dummy : Unit
    {
        public DateTime LastDamaged { get; set; }
        public Dummy() { }

        public void SetResistances(float amount)
        {
            this.Stats["BonusArmor"] += amount - this.Armor;
            this.Stats["BonusMR"] += amount - this.MR;
        }

        public void AddResistances(float amount)
        {
            this.Stats["BonusArmor"] += amount;
            this.Stats["BonusMR"] += amount;
        }

        public void RemoveResistances(float amount)
        {
            this.Stats["BonusArmor"] -= amount;
            this.Stats["BonusMR"] -= amount;
        }

        public override void TakeDamage(double damage)
        {
            if (CurrentHP - damage <= 1) { CurrentHP = 1; }
            else { CurrentHP -= (float)damage; }
        }

        public override BasicAttackResult BasicAttack(Unit target)
        {
            return new BasicAttackResult(this, target);
        }
    }
}
