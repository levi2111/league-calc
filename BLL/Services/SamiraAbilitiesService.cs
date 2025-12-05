using Core.Models;
using Core.Models.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    // testing purposes only
    public class SamiraAbilitiesService
    {
        public SamiraAbilitiesService() { }

        public Ability GetQ()
        {

            int maxRank = 5;
            DamageType damageType = DamageType.Physical;
            double[] baseDamage = [0, 5, 10, 15, 20];
            Dictionary<string, double[]> scalings = new Dictionary<string, double[]>
            {
                {"AD", [0.95, 1.025, 1.1, 1.175, 1.25]}
            };
            bool unlockedByDefault = false;
            bool ultimateAbility = false;

            BaseAbility qBase = new(maxRank, damageType, baseDamage, scalings,
                unlockedByDefault, ultimateAbility);

            return new(qBase);
        }

        public Ability GetW()
        {

            int maxRank = 5;
            DamageType damageType = DamageType.Physical;
            double[] baseDamage = [20, 35, 50, 65, 80];
            Dictionary<string, double[]> scalings = new Dictionary<string, double[]>
            {
                {"BonusAD", [0.6, 0.6, 0.6, 0.6, 0.6]}
            };
            bool unlockedByDefault = false;
            bool ultimateAbility = false;

            BaseAbility wBase = new(maxRank, damageType, baseDamage, scalings,
                unlockedByDefault, ultimateAbility);

            return new(wBase);
        }

        public Ability GetE()
        {

            int maxRank = 5;
            DamageType damageType = DamageType.Magical;
            double[] baseDamage = [50, 60, 70, 80, 90];
            Dictionary<string, double[]> scalings = new Dictionary<string, double[]>
            {
                {"BonusAD", [0.2, 0.2, 0.2, 0.2, 0.2]}
            };
            bool unlockedByDefault = false;
            bool ultimateAbility = false;

            BaseAbility eBase = new(maxRank, damageType, baseDamage, scalings,
                unlockedByDefault, ultimateAbility);

            return new(eBase);
        }

        public Ability GetR()
        {

            int maxRank = 3;
            DamageType damageType = DamageType.Physical;
            double[] baseDamage = [5, 15, 25];
            Dictionary<string, double[]> scalings = new Dictionary<string, double[]>
            {
                {"AD", [0.45, 0.45, 0.45]}
            };
            bool unlockedByDefault = false;
            bool ultimateAbility = true;

            BaseAbility rBase = new(maxRank, damageType, baseDamage, scalings,
                unlockedByDefault, ultimateAbility);

            return new(rBase);
        }
    }
}
