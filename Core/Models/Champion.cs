using Core.Interfaces;
using Core.Models.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Champion : Unit
    {
        private BaseChampion BaseChampion { get; set; }
        public Ability Q { get; set; }
        public Ability W { get; set; }
        public Ability E { get; set; }
        public Ability R { get; set; }
        public Champion(BaseChampion baseChampion)
        {
            BaseChampion = baseChampion;
            Stats["HPRegen"] = baseChampion.BaseStaticHPRegen; // ?
            Stats["BaseHPRegen"] = baseChampion.BaseStaticHPRegen;
            Stats["BonusHPRegen"] = 0;
            Stats["HPRegenPerLevel"] = baseChampion.HPRegenPerLevel;
            Stats["Lethality"] = 0;
            Stats["ArmorPen"] = 0;
            Stats["FlatMagicPen"] = 0;
            Stats["MagicPen"] = 0;
            Stats["CritChance"] = 0;
            Stats["CritDamage"] = 1.75f;
            Stats["Tenacity"] = 0;
            Stats["SlowResistance"] = 0;
            Stats["HealAndShieldPower"] = 0;
            Stats["Lifesteal"] = 0;
            Stats["Omnivamp"] = 0;
        }

        public override string ToString()
        {
            return $"Lv{Level} {BaseChampion.Name} (ID: {Id})";
        }
    }
}
