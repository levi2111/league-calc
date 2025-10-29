using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PrimaryAbilityResource : IAbilityResource
    {
        public int? arType { get; }
        // 0 = mana, 1 = energy, 4 = rage, 5 = fury, 8 = grit
        public double arBase { get; }
        public double arBaseStaticRegen { get; }
        public double? arPerLevel { get; }
        public double? arRegenPerLevel { get; }
        public double? arIncrements { get; }

        public double BaseMax { get; private set; }
        public double BonusMax { get; private set; }
        public double TotalMax { get; private set; }
        public double BaseRegen { get; private set; }
        public double BonusRegen { get; private set; }
        public double TotalRegen { get; private set; }
        public double CurrentAmount { get; private set; }

        public PrimaryAbilityResource(int? arType, double arBase, double arBaseStaticRegen, double? arPerLevel, double? arRegenPerLevel, double? arIncrements)
        {
            this.arType = arType;
            this.arBase = arBase;
            this.BaseMax = arBase;
            this.BonusMax = 0;
            this.TotalMax = arBase;
            this.BaseRegen = arBaseStaticRegen;
            this.BonusRegen = 0;
            this.TotalRegen = arBaseStaticRegen;
            this.CurrentAmount = arBase;
            this.arBaseStaticRegen = arBaseStaticRegen;
            this.arPerLevel = arPerLevel;
            this.arRegenPerLevel = arRegenPerLevel;
            this.arIncrements = arIncrements;
        }

        public bool Use(double amount)
        {
            if (amount > CurrentAmount)
            {
                return false;
            }

            CurrentAmount -= amount;
            return true;
        }

        public void Regen()
        {
            if (CurrentAmount + this.TotalRegen > this.TotalMax)
            {
                CurrentAmount = this.TotalMax;
            }
            else
            {
                CurrentAmount += this.TotalRegen;
            }
        }

        public void Increment()
        {
            if (CurrentAmount + this.arIncrements > this.TotalMax)
            {
                CurrentAmount = this.TotalMax;
            }
            else
            {
                CurrentAmount += this.arIncrements ?? 0;
            }
        }
    }
}
