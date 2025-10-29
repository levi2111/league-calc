using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStats
    {
        int Level { get; set; }

        float CurrentHP { get; set; }
        float BaseHP { get; set; }
        float BonusHP { get; set; }
        float MaxHP { get; }
        float HPPerLevel { get; set; }

        float HPRegen { get; set; }
        float BaseHPRegen { get; set; }
        float BonusHPRegen { get; set; }
        float HPRegenPerLevel { get; set; }

        PrimaryAbilityResource? PrimaryAbilityResource { get; set; }
        IAbilityResource? SecondaryAbilityResource { get; set; }

        float BaseAD { get; set; }
        float BonusAD { get; set; }
        float AD { get; }
        float ADPerLevel { get; set; }

        float AP { get; set; }

        float BaseAttackSpeed { get; set; }
        float BonusAttackSpeed { get; set; }
        float AttackSpeed { get; }
        float AttackSpeedRatio { get; set; }
        float AttackSpeedPerLevel { get; set; }

        float AttackRange { get; set; }

        float BaseArmor { get; set; }
        float BonusArmor { get; set; }
        float Armor { get; }
        float ArmorPerLevel { get; set; }
        float BaseMR { get; set; }
        float BonusMR { get; set; }
        float MR { get; }
        float MRPerLevel { get; set; }

        float AbilityHaste { get; set; }
        float Lethality { get; set; }
        float ArmorPen { get; set; }
        float FlatMagicPen { get; set; }
        float MagicPen { get; set; }

        float CritChance { get; set; }
        float CritDamageMultiplier { get; set; }
        float CritDamage { get; }

        float BaseMoveSpeed { get; set; }
        float BonusMoveSpeed { get; set; }
        float MoveSpeed { get; }

        float Tenacity { get; set; }
        float SlowResistance { get; set; }

        float HealAndShieldPower { get; set; }

        float Lifesteal { get; set; }
        float Omnivamp { get; set; }

        float Gold { set; get; }
        float XP { set; get; }

        float Shield { get; set; }
    }

}
