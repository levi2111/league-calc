using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseChampion : IBaseChampion
    {
        public string Name { get; }
        public string Patch { get; }
        public double BaseHP { get; }
        public double HPPerLevel { get; }
        public double BaseStaticHPRegen { get; }
        public double HPRegenPerLevel { get; }
        public IAbilityResource PrimaryAbilityResource {  get; }
        public double BaseAD { get; }
        public double ADPerLevel { get; }
        public double BaseArmor { get; }
        public double ArmorPerLevel { get; }
        public double BaseMR { get; }
        public double MRPerLevel { get; }
        public double BaseMovementSpeed { get; }
        public double AttackRange { get; }
        public double BaseAttackSpeed { get; }
        public double AttackSpeedPerLevel { get; }
        public double AttackSpeedRatio { get; }

        public BaseChampion(
            string name,
            string patch,
            double baseHP,
            double hpPerLevel,
            double baseStaticHPRegen,
            double hpRegenPerLevel,
            IAbilityResource primaryAbilityResource,
            double baseAD,
            double adPerLevel,
            double baseArmor,
            double armorPerLevel,
            double baseMR,
            double mrPerLevel,
            double baseMovementSpeed,
            double attackRange,
            double baseAttackSpeed,
            double attackSpeedPerLevel,
            double attackSpeedRatio)
        {
            Name = name;
            Patch = patch;
            BaseHP = baseHP;
            HPPerLevel = hpPerLevel;
            BaseStaticHPRegen = baseStaticHPRegen;
            HPRegenPerLevel = hpRegenPerLevel;
            PrimaryAbilityResource = primaryAbilityResource;
            BaseAD = baseAD;
            ADPerLevel = adPerLevel;
            BaseArmor = baseArmor;
            ArmorPerLevel = armorPerLevel;
            BaseMR = baseMR;
            MRPerLevel = mrPerLevel;
            BaseMovementSpeed = baseMovementSpeed;
            AttackRange = attackRange;
            BaseAttackSpeed = baseAttackSpeed;
            AttackSpeedPerLevel = attackSpeedPerLevel;
            AttackSpeedRatio = attackSpeedRatio;
        }
    }
}
