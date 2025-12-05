using Core.Interfaces;
using Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abilities
{
    public class BaseAbility : IBaseAbility
    {
        public int MaxRank { get; }
        public DamageType DamageType { get; }
        public double[] BaseDamage { get; }
        public double[] Cooldown { get; }
        public Dictionary<string, double[]> Scalings { get; }
        
        public bool UnlockedByDefault { get; }
        public bool UltimateAbility { get; }

        public BaseAbility(int maxRank, DamageType damageType, double[] baseDamage,
            Dictionary<string, double[]> scalings, bool unlockedByDefault, bool ultimateAbility)
        {
            MaxRank = maxRank;
            DamageType = damageType;
            BaseDamage = baseDamage;
            Scalings = scalings;
            UnlockedByDefault = unlockedByDefault;
            UltimateAbility = ultimateAbility;
        }
    }
}
