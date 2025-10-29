using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseChampion
    {
        string Name { get; }
        string Patch {  get; }
        double BaseHP { get; }
        double HPPerLevel { get; }
        IAbilityResource PrimaryAbilityResource { get; }
        double BaseAD { get; }
        double ADPerLevel { get; }
        double BaseArmor { get; }
        double ArmorPerLevel { get; }
        double BaseMR { get; }
        double MRPerLevel { get; }
        double BaseMovementSpeed { get; }
        double AttackRange { get; }
        double BaseAttackSpeed { get; }
        double AttackSpeedPerLevel { get; }
        double AttackSpeedRatio { get; }
    }
}
