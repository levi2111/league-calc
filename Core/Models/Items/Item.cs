using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Item
{
    public class Item
    {
        public readonly int Id;
        public readonly string Name;
        public Dictionary<string, int> Stats { get; private set; }
        public double TotalCost;
        public double CombineCost;
        public int[] From;
        public int[] To;
        public string[] Gamemodes;
        public int MaxStack;

        public Item(int id, string name, Dictionary<string, int> stats, double totalCost,
                    double combineCost, int[] from, int[] to, string[] gamemodes, int maxStack)
        {
            Id = id;
            Name = name;
            Stats = stats;
            TotalCost = totalCost;
            CombineCost = combineCost;
            From = from;
            To = to;
            Gamemodes = gamemodes;
            MaxStack = maxStack;
        }
    }
}
