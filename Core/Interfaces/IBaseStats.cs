using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseStats
    {
        double? BaseHP { get; set; }
        double? HPPerLevel { get; set; }
        double? BaseMP { get; set; }
        double? MPPerLevel { get; set; }
        double? BaseAD { get; set; }
        double? ADPerLevel { get; set; }
        double? BaseArmor { get; set; }
        double? ArmorPerLevel { get; set; }
        double? BaseMR { get; set; }
        double? MRPerLevel { get; set; }
        double? BaseMovementSpeed { get; set; }
        double? AttackRange { get; set; }
        double? BaseAttackSpeed { get; set; }
        double? AttackSpeedPerLevel { get; set; }
        double? AttackSpeedRatio { get; set; }
    }
}
