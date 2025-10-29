using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseStats
    {
        public double BaseHP { get; }
        public double HPPerLevel { get; }
        public double BaseHPRegen { get; }
        public double HPRegenPerLevel { get; }
        public double BaseAD { get; }
        public double ADPerLevel { get; }
        public double BaseArmor { get; }
        public double ArmorPerLevel { get; }
        public double BaseMR { get; }
        public double MRPerLevel { get; }
        public double BaseMoveSpeed { get; }
        public double AttackRange { get; }
        public double BaseAttackSpeed { get; }
        public double AttackSpeedRatio { get; }
        public double AttackSpeedPerLevel { get; }

        public BaseStats(
    double baseHP,
    double hpPerLevel,
    double baseHPRegen,
    double hpRegenPerLevel,
    double baseAD,
    double adPerLevel,
    double baseArmor,
    double armorPerLevel,
    double baseMR,
    double mrPerLevel,
    double baseMoveSpeed,
    double attackRange,
    double baseAttackSpeed,
    double attackSpeedRatio,
    double attackSpeedPerLevel)
        {
            BaseHP = baseHP;
            HPPerLevel = hpPerLevel;
            BaseHPRegen = baseHPRegen;
            HPRegenPerLevel = hpRegenPerLevel;
            BaseAD = baseAD;
            ADPerLevel = adPerLevel;
            BaseArmor = baseArmor;
            ArmorPerLevel = armorPerLevel;
            BaseMR = baseMR;
            MRPerLevel = mrPerLevel;
            BaseMoveSpeed = baseMoveSpeed;
            AttackRange = attackRange;
            BaseAttackSpeed = baseAttackSpeed;
            AttackSpeedRatio = attackSpeedRatio;
            AttackSpeedPerLevel = attackSpeedPerLevel;
        }
    }
}
