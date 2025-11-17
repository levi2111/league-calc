using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseChampion : IBaseChampion
    {
        public string Name { get; }
        public string FormattedName { get; }
        public string Patch { get; }
        public float BaseHP { get; }
        public float HPPerLevel { get; }
        public float BaseStaticHPRegen { get; }
        public float HPRegenPerLevel { get; }
        public PrimaryAbilityResource PrimaryAbilityResource {  get; }
        public float BaseAD { get; }
        public float ADPerLevel { get; }
        public float BaseArmor { get; }
        public float ArmorPerLevel { get; }
        public float BaseMR { get; }
        public float MRPerLevel { get; }
        public float BaseMovementSpeed { get; }
        public float AttackRange { get; }
        public float BaseAttackSpeed { get; }
        public float AttackSpeedPerLevel { get; }
        public float AttackSpeedRatio { get; }
        public Dictionary<string, string> AbilityScriptNames { get; }

        [JsonConstructor]
        public BaseChampion(
            string name,
            string formattedName,
            string patch,
            float baseHP,
            float hpPerLevel,
            float baseStaticHPRegen,
            float hpRegenPerLevel,
            PrimaryAbilityResource primaryAbilityResource,
            float baseAD,
            float adPerLevel,
            float baseArmor,
            float armorPerLevel,
            float baseMR,
            float mrPerLevel,
            float baseMovementSpeed,
            float attackRange,
            float baseAttackSpeed,
            float attackSpeedPerLevel,
            float attackSpeedRatio)
        {
            Name = name;
            FormattedName = formattedName;
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
            AbilityScriptNames = new Dictionary<string, string>
            {
                { "Q", $"{formattedName}Q"},
                { "W", $"{formattedName}W"},
                { "E", $"{formattedName}E"},
                { "R", $"{formattedName}R"}
            };
        }
    }
}
