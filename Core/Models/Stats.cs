using Core.Interfaces;
using Core.Models.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Stats
    {
        public int Level { get; set; }
         
        public float CurrentHP { get; set; }
        public float BaseHP { get; set; }
        public float BonusHP { get; set; }
        public float MaxHP
        {
            get
            {
                return BaseHP + BonusHP;
            }
        }
        public float HPPerLevel { get; set; }
         
        public float HPRegen { get; set; }
        public float BaseHPRegen { get; set; }
        public float BonusHPRegen { get; set; }
        public float HPRegenPerLevel { get; set; }
         
        public PrimaryAbilityResource? PrimaryAbilityResource { get; set; }
        public IAbilityResource? SecondaryAbilityResource { get; set; }
         
        public float BaseAD { get; set; }
        public float BonusAD { get; set; }
        public float AD { get; }
        public float ADPerLevel { get; set; }
         
        public float AP { get; set; }
        public float BaseAttackSpeed { get; set; }
        public float BonusAttackSpeed { get; set; }
        public float AttackSpeed { get; }
        public float AttackSpeedRatio { get; set; }
        public float AttackSpeedPerLevel { get; set; }
         
        public float AttackRange { get; set; }
         
        public float BaseArmor { get; set; }
        public float BonusArmor { get; set; }
        public float Armor { get; }
        public float ArmorPerLevel { get; set; }
        public float BaseMR { get; set; }
        public float BonusMR { get; set; }
        public float MR { get; }
        public float MRPerLevel { get; set; }
         
        public float AbilityHaste { get; set; }
        public float Lethality { get; set; }
        public float ArmorPen { get; set; }
        public float FlatMagicPen { get; set; }
        public float MagicPen { get; set; }
         
        public float CritChance { get; set; }
        public float CritDamageMultiplier { get; set; }
        public float CritDamage { get; }
         
        public float BaseMoveSpeed { get; set; }
        public float BonusMoveSpeed { get; set; }
        public float MoveSpeed { get; }
         
        public float Tenacity { get; set; }
        public float SlowResistance { get; set; }
         
        public float HealAndShieldPower { get; set; }
         
        public float Lifesteal { get; set; }
        public float Omnivamp { get; set; }

        List<Effect> ActiveEffects = new List<Effect>();

        public Stats(int level, float baseHP, float hPPerLevel, float hPRegen, float baseHPRegen, float bonusHPRegen, float hPRegenPerLevel, PrimaryAbilityResource? primaryAbilityResource, IAbilityResource? secondaryAbilityResource, float baseAD, float bonusAD, float aD, float aDPerLevel, float aP, float baseAttackSpeed, float bonusAttackSpeed, float attackSpeed, float attackSpeedRatio, float attackSpeedPerLevel, float attackRange, float baseArmor, float bonusArmor, float armor, float armorPerLevel, float baseMR, float bonusMR, float mR, float mRPerLevel, float abilityHaste, float lethality, float armorPen, float flatMagicPen, float magicPen, float critChance, float critDamageMultiplier, float critDamage, float baseMoveSpeed, float bonusMoveSpeed, float moveSpeed, float tenacity, float slowResistance, float healAndShieldPower, float lifesteal, float omnivamp, float gold, float xP, float shield)
        {
            Level = 1;
            CurrentHP = baseHP;
            BaseHP = baseHP;
            BonusHP = 0;
            HPPerLevel = hPPerLevel;
            BaseHPRegen = baseHPRegen;
            BonusHPRegen = 0;
            HPRegenPerLevel = hPRegenPerLevel;
            PrimaryAbilityResource = primaryAbilityResource;
            SecondaryAbilityResource = secondaryAbilityResource;
            BaseAD = baseAD;
            BonusAD = 0;
            ADPerLevel = aDPerLevel;
            AP = 0;
            BaseAttackSpeed = baseAttackSpeed;
            BonusAttackSpeed = 0;
            AttackSpeedRatio = attackSpeedRatio;
            AttackSpeedPerLevel = attackSpeedPerLevel;
            AttackRange = attackRange;
            BaseArmor = baseArmor;
            BonusArmor = 0;
            ArmorPerLevel = armorPerLevel;
            BaseMR = baseMR;
            BonusMR = 0;
            MRPerLevel = mRPerLevel;
            AbilityHaste = 0;
            Lethality = 0;
            ArmorPen = 0;
            FlatMagicPen = 0;
            MagicPen = 0;
            CritChance = 0;
            CritDamageMultiplier = 0;
            CritDamage = 0;
            BaseMoveSpeed = baseMoveSpeed;
            BonusMoveSpeed = 0;
            MoveSpeed = baseMoveSpeed;
            Tenacity = 0;
            SlowResistance = 0;
            HealAndShieldPower = 0;
            Lifesteal = 0;
            Omnivamp = 0;
        }
    }
}
