using Core.Models;
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
        float BaseHP { get; }
        float HPPerLevel { get; }
        PrimaryAbilityResource PrimaryAbilityResource { get; }
        float BaseAD { get; }
        float ADPerLevel { get; }
        float BaseArmor { get; }
        float ArmorPerLevel { get; }
        float BaseMR { get; }
        float MRPerLevel { get; }
        float BaseMovementSpeed { get; }
        float AttackRange { get; }
        float BaseAttackSpeed { get; }
        float AttackSpeedPerLevel { get; }
        float AttackSpeedRatio { get; }
    }
}
