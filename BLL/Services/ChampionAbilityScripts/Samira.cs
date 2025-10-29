using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ChampionAbilityScripts
{
    public class Samira
    {
        public Samira() { }

        private Damage pBonusMeleeDamage(Champion sender, Unit receiver)
        {
            double rawPDamage1 = sender.Level + 1;
            double rawPDamage2 = (sender.Level - 1) * (10.5 - 3.5) / 17;
            double rawPDamage = (rawPDamage1 + rawPDamage2) * (2 - (receiver.CurrentHP / receiver.HP));

            Damage pDamage = new Damage(rawPDamage, DamageType.Magical, sender, receiver);
            return pDamage;
        }

        private double rawQDmg(Champion sender, int rank)
        {
            double[] baseDamage = [0, 5, 10, 15, 20];
            double[] totalAdScaling = [0.95, 1.025, 1.1, 1.175, 1.25];

            double preMitigationDamage = baseDamage[rank] + totalAdScaling[rank] * sender.AD;

            return preMitigationDamage;
        }

        public Damage RangedQ(Champion sender, Unit receiver, int rank)
        {
            return new Damage(rawQDmg(sender, rank), DamageType.Physical, sender, receiver);
        }

        public Damage RangedQCrit(Champion sender, Unit receiver, int rank)
        {
            double rawDamage = rawQDmg(sender, rank) * sender.Stats.CritChance
            return new Damage(rawQDmg(sender, rank), DamageType.Physical, sender, receiver);
        }

        public Damage[] MeleeQ(Champion sender, Unit receiver, int rank)
        {
            Damage qDamage = new Damage(rawQDmg(sender, rank), DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            return [qDamage, pDamage];
        }

        public Damage[] W1(Champion sender, Unit receiver, int rank)
        {
            double[] baseDamage = [20, 35, 50, 65, 80];
            double[] bonusAdScaling = [0.6, 0.6, 0.6, 0.6, 0.6];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.BonusAD;
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);
            
            return [wDamage, pDamage];
        }

        public Damage[] W2(Champion sender, Unit receiver, int rank)
        {
            double[] baseDamage = [20, 35, 50, 65, 80];
            double[] bonusAdScaling = [0.6, 0.6, 0.6, 0.6, 0.6];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.BonusAD;
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            return [wDamage, pDamage];
        }

        public Damage[] E(Champion sender, Unit receiver, int rank)
        {
            double[] baseDamage = [50, 60, 70, 80, 90];
            double[] bonusAdScaling = [0.2, 0.2, 0.2, 0.2, 0.2];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.BonusAD;
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            return [wDamage, pDamage];
        }

        public Damage[] R(Champion sender, Unit receiver, int rank)
        {
            double[] baseDamage = [50, 60, 70, 80, 90];
            double[] bonusAdScaling = [0.2, 0.2, 0.2, 0.2, 0.2];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.BonusAD;
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            return [wDamage, pDamage];
        }
    }
}
