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
        public Dictionary<string, double> Scalings { get; }
        
        // do i want any of these ??? idk yet should probably go into mutations
        public bool IsProjectile { get; }
        public bool ProcsOnHit { get; set; }
        public bool CanCrit { get; set; }
        public double? CritDamage { get; set; }
        public bool UnlockedByDefault { get; }
        public bool UltimateAbility { get; }

        public BaseAbility(int maxRank, DamageType damageType, double[] baseDamage,
            Dictionary<string, double> scalings, bool isProjectile, bool procsOnHit,
            bool canCrit, double? critDamage, bool unlockedByDefault, bool ultimateAbility)
        {
            MaxRank = maxRank;
            DamageType = damageType;
            BaseDamage = baseDamage;
            Scalings = scalings;
            IsProjectile = isProjectile;
            ProcsOnHit = procsOnHit;
            CanCrit = canCrit;
            CritDamage = critDamage;
            UnlockedByDefault = unlockedByDefault;
            UltimateAbility = ultimateAbility;
        }
    }
}
