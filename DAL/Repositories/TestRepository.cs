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
    public class TestRepository : IReadOnlyChampionRepository
    {
        private FormatterService _formatter;
        private string latestPatch = "25.23";

        public TestRepository()
        {
            _formatter = new FormatterService();
            Console.WriteLine("initialized");
        }

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

            double arBase;
            if (par.TryGetProperty("arBase", out var arBaseProp))
                arBase = arBaseProp.GetDouble();
            else
                arBase = 0;

            double arBaseStaticRegen;
            if (par.TryGetProperty("arBaseStaticRegen", out var arBaseStaticRegenProp))
                arBaseStaticRegen = arBaseStaticRegenProp.GetDouble();
            else
                arBaseStaticRegen = 0;

            double? arPerLevel;
            if (par.TryGetProperty("arPerLevel", out var arPerLevelProp))
                arPerLevel = arPerLevelProp.GetDouble();
            else
                arPerLevel = null;

            double? arRegenPerLevel;
            if (par.TryGetProperty("arRegenPerLevel", out var arRegenPerLevelProp))
                arRegenPerLevel = arRegenPerLevelProp.GetDouble();
            else
                arRegenPerLevel = null;

            double? arIncrements;
            if (par.TryGetProperty("arIncrements", out var arIncrementsProp))
                arIncrements = arIncrementsProp.GetDouble();
            else
                arIncrements = null;

            IAbilityResource primaryAbilityResource = new PrimaryAbilityResource(
                arType, arBase, arBaseStaticRegen, arPerLevel, arRegenPerLevel, arIncrements);

            double baseHP = root.GetProperty("baseDamage").GetDouble();
            double hpPerLevel = root.GetProperty("hpPerLevel").GetDouble();
            double baseStaticHPRegen = root.GetProperty("baseStaticHPRegen").GetDouble();
            double hpRegenPerLevel = root.GetProperty("hpRegenPerLevel").GetDouble();
            double baseAD = root.GetProperty("baseDamage").GetDouble();
            double adPerLevel = root.GetProperty("damagePerLevel").GetDouble();
            double baseArmor = root.GetProperty("baseArmor").GetDouble();
            double armorPerLevel = root.GetProperty("armorPerLevel").GetDouble();
            double baseMR = root.GetProperty("baseSpellBlock").GetDouble();
            double mrPerLevel = root.GetProperty("spellBlockPerLevel").GetDouble();
            double baseMovementSpeed = root.GetProperty("baseMoveSpeed").GetDouble();
            double attackRange = root.GetProperty("attackRange").GetDouble();
            double baseAttackSpeed = root.GetProperty("attackSpeed").GetDouble();
            double attackSpeedPerLevel = root.GetProperty("attackSpeedPerLevel").GetDouble();
            double attackSpeedRatio = root.GetProperty("attackSpeedRatio").GetDouble();

            BaseChampion Samira = new(
                    "Samira", latestPatch, baseHP, hpPerLevel, baseStaticHPRegen, hpRegenPerLevel,
                    primaryAbilityResource, baseAD, adPerLevel, baseArmor, armorPerLevel, baseMR, mrPerLevel,
                    baseMovementSpeed, attackRange, baseAttackSpeed, attackSpeedPerLevel, hpPerLevel);
            return Samira;
        }

        public async Task<BaseChampion> GetByName(string name)
        {
            if (_formatter.GetCDragonChampionName(name).ToLower() == "samira")
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
