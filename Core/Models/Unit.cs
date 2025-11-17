using Core.Interfaces;
using Core.Models.Effects;
using Core.Models.Results;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class Unit : IUnit
    {
        public static int ID_COUNTER = 0;

        public int Id { get; }
        public virtual int Level { get; protected set; }
        public float CurrentHP { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMelee { get; }
        public Dictionary<string, float> Stats { get; set; } = new Dictionary<string, float>
        {
            ["Level"] = 0,
            ["BaseHP"] = 0,
            ["BonusHP"] = 0,
            ["MaxHP"] = 0,
            ["HPPerLevel"] = 0,
            ["BaseAD"] = 0,
            ["BonusAD"] = 0,
            ["ADPerLevel"] = 0,
            ["BaseAttackSpeed"] = 0,
            ["BonusAttackSpeed"] = 0,
            ["AttackSpeed"] = 0,
            ["AttackSpeedRatio"] = 0,
            ["AttackSpeedPerLevel"] = 0,
            ["AttackRange"] = 0,
            ["BaseArmor"] = 0,
            ["BonusArmor"] = 0,
            ["ArmorPerLevel"] = 0,
            ["BaseMR"] = 0,
            ["BonusMR"] = 0,
            ["MRPerLevel"] = 0,
            ["BaseMoveSpeed"] = 0,
            ["BonusMoveSpeed"] = 0
        };

        public float MaxHP => Stats["BaseHP"] + Stats["BonusHP"];
        public float AD => Stats["BaseAD"] + Stats["BonusAD"];
        public float AP = 0;
        public float AttackSpeed => Stats["BaseAttackSpeed"] + Stats["AttackSpeedRatio"] * Stats["BonusAttackSpeed"];
        public float Armor => Stats["BaseArmor"] + Stats["BonusArmor"];
        public float MR => Stats["BaseMR"] + Stats["BonusMR"];
        public float HPRegen => Stats["BaseHPRegen"] + Stats["BonusHPRegen"];
        public float AbilityHaste = 0;
        public float MoveSpeed => Stats["BaseMoveSpeed"] + Stats["BonusMoveSpeed"];
        public List<Effect> Effects = new();

        public Unit()
        {
            Id = ID_COUNTER;
            ID_COUNTER++;

            Stats["Level"] = 1;
            Stats["CurrentHP"] = 100;
            Stats["BaseHP"] = 100;
            Stats["BonusHP"] = 0;
            Stats["MaxHP"] = 100;
            Stats["HPPerLevel"] = 0;
            Stats["BaseAD"] = 0;
            Stats["BonusAD"] = 0;
            Stats["AD"] = 0;
            Stats["ADPerLevel"] = 0;
            Stats["AP"] = 0;
            Stats["BaseAttackSpeed"] = 0;
            Stats["BonusAttackSpeed"] = 0;
            Stats["AttackSpeed"] = 0;
            Stats["AttackSpeedRatio"] = 0;
            Stats["AttackSpeedPerLevel"] = 0;
            Stats["AttackRange"] = 0;
            Stats["BaseArmor"] = 0;
            Stats["BonusArmor"] = 0;
            Stats["Armor"] = 0;
            Stats["ArmorPerLevel"] = 0;
            Stats["BaseMR"] = 0;
            Stats["BonusMR"] = 0;
            Stats["MR"] = 0;
            Stats["MRPerLevel"] = 0;
            Stats["AbilityHaste"] = 0;
            Stats["BaseMoveSpeed"] = 0;
            Stats["BonusMoveSpeed"] = 0;
            Stats["MoveSpeed"] = 0;
            Stats["BaseHPRegen"] = 0;
            Stats["BonusHPRegen"] = 0;

            Inventory = new Inventory();
            IsMelee = true;
            CurrentHP = 100;
        }

        public virtual void TakeDamage(double damage)
        {
            if (CurrentHP - damage <= 0) { CurrentHP = 0; }
            else { CurrentHP -= (float)damage; }
        }

        public virtual BasicAttackResult BasicAttack(Unit target)
        {
            Damage dmg = new Damage(AD, DamageType.Physical, this, target);
            target.TakeDamage(dmg.PostMitigationDamage);

            BasicAttackResult basicAttackResult = new(this, target);
            return basicAttackResult;
        }
    }
}
