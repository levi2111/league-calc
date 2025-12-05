using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseAbility
    {
        int MaxRank { get; }
        DamageType DamageType { get; }
        double[] BaseDamage { get; }
        Dictionary<string, double[]> Scalings { get; }
        bool UnlockedByDefault { get; }
        bool UltimateAbility { get; }
    }
}
