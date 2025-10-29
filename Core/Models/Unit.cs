using Core.Interfaces;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Unit : IUnit
    {
        public virtual int Level { get; protected set; }
        public double CurrentHP { get; set; }
        public double MaxHP { get; set; }
        public Inventory Inventory { get; }
        public bool IsMelee { get; }

        public double AttackRange;
        public double HP 
        { 
            get
            {
                return BaseHP + BonusHP;
            } 
        }
        public double AD
        {
            get
            {
                return BaseAD + BonusAD;
            }
        }
        public double AP;
        public double AttackSpeed 
        { 
            get
            {
                return BaseAttackSpeed + AttackSpeedRatio * BonusAttackSpeed;
            } 
        }
        public double Armor
        {
            get
            {
                return BaseArmor + BonusArmor;
            }
        }
        public double MR
        {
            get
            {
                return BaseMR + BonusMR;
            }
        }
        public double MP
        {
            get
            {
                return BaseMP + BonusMP;
            }
        }
        public double MPRegen
        {
            get
            {
                return BaseMPRegen + BonusMPRegen;
            }
        }
        public double HPRegen
        {
            get
            {
                return BaseHPRegen + BonusHPRegen;
            }
        }

        public double CDR;
        public double Lethality;
        public double ArmorPen;
        public double FlatMagicPen;
        public double MagicPen;
        public double CritChance;
        public double CritDamage;

        public double AttackSpeedRatio;

        public double BaseHP;
        public double BonusHP;
        public double BaseAD;
        public double BonusAD;
        public double BaseAttackSpeed;
        public double BonusAttackSpeed;
        public double BaseArmor;
        public double BonusArmor;
        public double BaseMR;
        public double BonusMR;
        public double BaseMP;
        public double BonusMP;
        public double BaseMPRegen;
        public double BonusMPRegen;
        public double BaseHPRegen;
        public double BonusHPRegen;

        public Unit()
        {
            Inventory = new Inventory();
            CDR = 0;
            Lethality = 0;
            ArmorPen = 0;
            FlatMagicPen = 0;
            MagicPen = 0;
            AttackSpeedRatio = 1;
            AttackRange = 100;
            CritChance = 0;
            CritDamage = 1.75;

            IsMelee = true;
            CurrentHP = 100;
            BaseHP = 100;
            BonusHP = 0;
            BaseAD = 0;
            BonusAD = 0;
            BaseAttackSpeed = 0.67;
            BonusAttackSpeed = 0;
            BaseArmor = 0;
            BonusArmor = 0;
            BaseMR = 0;
            BonusMR = 0;
            BaseMP = 600;
            BonusMP = 0;
            BaseMPRegen = 0;
            BonusMPRegen = 0;
            BaseHPRegen = 0;
            BonusHPRegen = 0;
        }

        public void TakeDamage(Damage d)
        {
            double damage = d.PostMitigationDamage;

            if (CurrentHP - damage<= 0) { CurrentHP = 0; }
            else { CurrentHP -= damage; }
        }

        public Damage BasicAttack(Unit target)
        {
            return new Damage(AD, DamageType.Physical, this, target);
        }
    }
}
