using Core.Interfaces;
using Core.Models;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repositories
{
    public class MockChampionRepository : IBaseChampionRepository
    {
        private string latestPatch = "25.23";

        public MockChampionRepository() { }

        public async Task<BaseChampion> GetSamira()
        {
            using var stream = File.OpenRead(@"../Data/Samira.JSON");
            using var document = await JsonDocument.ParseAsync(stream);

            JsonElement data = document.RootElement;
            JsonElement root = data.GetProperty("Characters/Samira/CharacterRecords/Root");
            JsonElement par = root.GetProperty("primaryAbilityResource");

            int? arType;
            if (par.TryGetProperty("arType", out var arTypeProp))
                arType = arTypeProp.GetInt32();
            else
                arType = null;

            float arBase;
            if (par.TryGetProperty("arBase", out var arBaseProp))
                arBase = (float)arBaseProp.GetDouble();
            else
                arBase = 0;

            float arBaseStaticRegen;
            if (par.TryGetProperty("arBaseStaticRegen", out var arBaseStaticRegenProp))
                arBaseStaticRegen = (float)arBaseStaticRegenProp.GetDouble();
            else
                arBaseStaticRegen = 0;

            float? arPerLevel;
            if (par.TryGetProperty("arPerLevel", out var arPerLevelProp))
                arPerLevel = (float)arPerLevelProp.GetDouble();
            else
                arPerLevel = null;

            float? arRegenPerLevel;
            if (par.TryGetProperty("arRegenPerLevel", out var arRegenPerLevelProp))
                arRegenPerLevel = (float)arRegenPerLevelProp.GetDouble();
            else
                arRegenPerLevel = null;

            float? arIncrements;
            if (par.TryGetProperty("arIncrements", out var arIncrementsProp))
                arIncrements = (float)arIncrementsProp.GetDouble();
            else
                arIncrements = null;

            PrimaryAbilityResource primaryAbilityResource = new PrimaryAbilityResource(
                arType, arBase, arBaseStaticRegen, arPerLevel, arRegenPerLevel, arIncrements);

            float baseHP = (float)root.GetProperty("baseDamage").GetDouble();
            float hpPerLevel = (float)root.GetProperty("hpPerLevel").GetDouble();
            float baseStaticHPRegen = (float)root.GetProperty("baseStaticHPRegen").GetDouble();
            float hpRegenPerLevel = (float)root.GetProperty("hpRegenPerLevel").GetDouble();
            float baseAD = (float)root.GetProperty("baseDamage").GetDouble();
            float adPerLevel = (float)root.GetProperty("damagePerLevel").GetDouble();
            float baseArmor = (float)root.GetProperty("baseArmor").GetDouble();
            float armorPerLevel = (float)root.GetProperty("armorPerLevel").GetDouble();
            float baseMR = (float)root.GetProperty("baseSpellBlock").GetDouble();
            float mrPerLevel = (float)root.GetProperty("spellBlockPerLevel").GetDouble();
            float baseMovementSpeed = (float)root.GetProperty("baseMoveSpeed").GetDouble();
            float attackRange = (float)root.GetProperty("attackRange").GetDouble();
            float baseAttackSpeed = (float)root.GetProperty("attackSpeed").GetDouble();
            float attackSpeedPerLevel = (float)root.GetProperty("attackSpeedPerLevel").GetDouble();
            float attackSpeedRatio = (float)root.GetProperty("attackSpeedRatio").GetDouble();

            string name = "Samira";
            string formattedName = FormatterService.GetCDragonChampionName("Samira");

            BaseChampion Samira = new(
                    name, formattedName, latestPatch, baseHP, hpPerLevel, baseStaticHPRegen, hpRegenPerLevel,
                    primaryAbilityResource, baseAD, adPerLevel, baseArmor, armorPerLevel, baseMR, mrPerLevel,
                    baseMovementSpeed, attackRange, baseAttackSpeed, attackSpeedPerLevel, hpPerLevel);
            return Samira;
        }

        public async Task<BaseChampion?> GetByName(string name)
        {
            if (FormatterService.GetCDragonChampionName(name).ToLower() == "samira")
            {
                return await GetSamira();
            }
            else { return null; }
        }

        public async Task<BaseChampion?> GetByNameAndPatch(string name, string patch)
        {
            if (name.ToLower() == "samira" && patch == latestPatch)
            {
                return await GetSamira() ;
            }
            else { return null; }
        }

        public async Task<IReadOnlyList<BaseChampion>> GetAll()
        {
            List<BaseChampion> all = new List<BaseChampion> { await GetSamira() };
            return all.ToArray();
        }

        public async Task<IReadOnlyList<BaseChampion>> GetAllByPatch(string patch)
        {
            List<BaseChampion> all = new List<BaseChampion>();
            if (patch == latestPatch)
            {
                all.Add(await GetSamira());
            }
            return all.ToArray();
        }
    }
}
