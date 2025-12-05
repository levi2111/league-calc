using Core.Models.Items;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MockItemRepository : IItemRepository
    {
        private string latestPatch = "25.23";

        public MockItemRepository() { }

        public Item GetInfinityEdge()
        {
            int id = 3031;
            string name = "Infinity Edge";
            Dictionary<string, double> stats = new Dictionary<string, double>
            {
                ["CritDamage"] = 0.5,
                ["CritChance"] = 0.25,
                ["AD"] = 80
            };
            double totalCost = 3400;
            double combineCost = 425;
            int[] from = new int[] { 1038, 1037, 1018 };
            int[] to = new int[] { 3371 };
            string[] gamemodes = new string[]
            {
                "ASCENSION",
                "ODIN",
                "CLASSIC",
                "ARSR",
                "ASSASSINATE",
                "DOOMBOTSTEEMO",
                "ONEFORALL",
                "SIEGE",
                "SNOWURF",
                "TUTORIAL",
                "URF",
                "ARAM",
                "FIRSTBLOOD",
                "KINGPORO",
                "STARGUARDIAN",
                "PROJECT",
                "TUTORIAL_MODULE_2",
                "TUTORIAL_MODULE_3",
                "PRACTICETOOL",
                "GAMEMODEX",
                "ODYSSEY"
            };
            int maxStacks = 1;
            Item ie = new(id, name, stats, totalCost, combineCost, from, to, gamemodes, maxStacks);

            return ie;
        }

        public Item GetCollector()
        {
            int id = 6676;
            string name = "The Collector";
            Dictionary<string, double> stats = new Dictionary<string, double>
            {
                ["Lethality"] = 10,
                ["CritChance"] = 0.25,
                ["AD"] = 50
            };
            double totalCost = 3000;
            double combineCost = 525;
            int[] from = new int[] { 3134, 1037, 1018 };
            int[] to = new int[] {  };
            string[] gamemodes = new string[]
            {
                "ASCENSION",
                "ODIN",
                "CLASSIC",
                "ARSR",
                "ASSASSINATE",
                "DOOMBOTSTEEMO",
                "ONEFORALL",
                "SIEGE",
                "SNOWURF",
                "TUTORIAL",
                "URF",
                "ARAM",
                "FIRSTBLOOD",
                "KINGPORO",
                "STARGUARDIAN",
                "PROJECT",
                "TUTORIAL_MODULE_2",
                "TUTORIAL_MODULE_3",
                "PRACTICETOOL",
                "GAMEMODEX",
                "ODYSSEY"
            };
            int maxStacks = 1;
            Item collector = new(id, name, stats, totalCost, combineCost, from, to, gamemodes, maxStacks);

            return collector;
        }

        public Item GetBloodthirster()
        {
            int id = 3072;
            string name = "Bloodthirster";
            Dictionary<string, double> stats = new Dictionary<string, double>
            {
                ["Lifesteal"] = 18,
                ["AD"] = 80
            };
            double totalCost = 3500;
            double combineCost = 950;
            int[] from = new int[] { 1038, 1036, 1053 };
            int[] to = new int[] {  };
            string[] gamemodes = new string[]
            {
                "CLASSIC",
                "ODIN",
                "TUTORIAL",
                "ARAM",
                "FIRSTBLOOD",
                "ASCENSION",
                "KINGPORO",
                "SIEGE",
                "ASSASSINATE",
                "URF",
                "ARSR",
                "STARGUARDIAN",
                "DOOMBOTSTEEMO",
                "PROJECT",
                "SNOWURF",
                "ONEFORALL",
                "TUTORIAL_MODULE_2",
                "TUTORIAL_MODULE_3",
                "PRACTICETOOL",
                "GAMEMODEX"
            };
            int maxStacks = 1;
            Item bt = new(id, name, stats, totalCost, combineCost, from, to, gamemodes, maxStacks);

            return bt;
        }

        public Task<IReadOnlyList<Item>> GetAll()
        {
            var items = new List<Item>() { GetBloodthirster(), GetCollector(), GetInfinityEdge() };
            return (Task<IReadOnlyList<Item>>)(IReadOnlyList<Item>)items;
        }

        public Task<Item> GetItemByIdAndPatch(int id, string patch)
        {
            return null;
        }
    }
}
