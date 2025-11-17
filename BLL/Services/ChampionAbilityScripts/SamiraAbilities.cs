using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ChampionAbilityScripts
{
    public class SamiraAbilities : IChampionAbilitiesScript
    {
        public SamiraAbilities() { }

        private Damage pBonusMeleeDamage(Champion sender, Unit receiver)
        {
            double rawPDamage1 = sender.Level + 1;
            double rawPDamage2 = (sender.Level - 1) * (10.5 - 3.5) / 17;
            double rawPDamage = (rawPDamage1 + rawPDamage2) * (2 - (receiver.CurrentHP / receiver.MaxHP));

            Damage pDamage = new Damage(rawPDamage, DamageType.Magical, sender, receiver);
            return pDamage;
        }

        private double rawQDmg(Champion sender)
        {
            int rank = sender.Q.CurrentRank;

            double[] baseDamage = [0, 5, 10, 15, 20];
            double[] totalAdScaling = [0.95, 1.025, 1.1, 1.175, 1.25];

            double preMitigationDamage = baseDamage[rank] + totalAdScaling[rank] * sender.AD;

            return preMitigationDamage;
        }

        private double rawQCritDmg(Champion sender)
        {
            int rank = sender.Q.CurrentRank;

            double[] baseDamage = [0, 5, 10, 15, 20];
            double[] totalAdScaling = [0.95, 1.025, 1.1, 1.175, 1.25];

            double preMitigationDamage = baseDamage[rank] + totalAdScaling[rank] * sender.AD;
            double critDamage = preMitigationDamage * (sender.Stats["CritDamage"] - 0.5); // Q crit scaling = 1.25

            return critDamage;
        }

        private Damage RangedQ(Champion sender, Unit receiver)
        {
            Damage dmg = new Damage(rawQDmg(sender), DamageType.Physical, sender, receiver);
            
            receiver.TakeDamage(dmg);

            return dmg;
        }

        private Damage RangedQCrit(Champion sender, Unit receiver)
        {
            Damage dmg = new Damage(rawQCritDmg(sender), DamageType.Physical, sender, receiver);
            
            receiver.TakeDamage(dmg);

            return dmg;
        }

        private Damage[] MeleeQ(Champion sender, Unit receiver)
        {
            Damage qDamage = new Damage(rawQDmg(sender), DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            receiver.TakeDamage(qDamage);
            receiver.TakeDamage(pDamage);

            return [qDamage, pDamage];
        }

        private Damage[] MeleeQCrit(Champion sender, Unit receiver)
        {
            Damage qDamage = new Damage(rawQCritDmg(sender), DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            receiver.TakeDamage(qDamage);
            receiver.TakeDamage(pDamage);

            return [qDamage, pDamage];
        }

        private Damage[] Q(Champion sender, Unit receiver, bool melee)
        {
            List<Damage> dmg = [];
            Random rnd = new();

            bool crit;

            if (rnd.Next(101) <= (int)(sender.Stats["CritChance"] * 100))
            {
                crit = true;
            }
            else
            {
                crit = false;
            }

            if (!melee && !crit) dmg.AddRange(RangedQ(sender, receiver));
            else if (!melee && crit) dmg.AddRange(RangedQCrit(sender, receiver));
            else if (melee && !crit) dmg.AddRange(MeleeQ(sender, receiver));
            else if (melee && crit) dmg.AddRange(MeleeQCrit(sender, receiver));

            return dmg.ToArray();
        }

        public Damage[] GetQDamage(Champion sender, Unit receiver, bool melee)
        {

        }

        private Damage[] W1(Champion sender, Unit receiver)
        {
            int rank = sender.W.CurrentRank;

            double[] baseDamage = [20, 35, 50, 65, 80];
            double[] bonusAdScaling = [0.6, 0.6, 0.6, 0.6, 0.6];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.Stats["BonusAD"];
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            receiver.TakeDamage(wDamage);
            receiver.TakeDamage(pDamage);

            return [wDamage, pDamage];
        }

        private Damage[] W2(Champion sender, Unit receiver)
        {
            int rank = sender.W.CurrentRank;

            double[] baseDamage = [20, 35, 50, 65, 80];
            double[] bonusAdScaling = [0.6, 0.6, 0.6, 0.6, 0.6];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.Stats["BonusAD"];
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            receiver.TakeDamage(wDamage);
            receiver.TakeDamage(pDamage);

            return [wDamage, pDamage];
        }

        public Damage[] W(Champion sender, Unit receiver)
        {
            Damage[] damage = new Damage[4];
            Damage[] w1 = W1(sender, receiver);
            Damage[] w2 = W2(sender, receiver);

            damage[0] = w1[0];
            damage[1] = w1[1];
            damage[2] = w2[0];
            damage[3] = w2[1];

            return damage;
        }

        public Damage[] E(Champion sender, Unit receiver)
        {
            int rank = sender.E.CurrentRank;

            double[] baseDamage = [50, 60, 70, 80, 90];
            double[] bonusAdScaling = [0.2, 0.2, 0.2, 0.2, 0.2];

            double preMitigationDamage = baseDamage[rank] + bonusAdScaling[rank] * sender.Stats["BonusAD"];
            Damage wDamage = new Damage(preMitigationDamage, DamageType.Physical, sender, receiver);
            Damage pDamage = pBonusMeleeDamage(sender, receiver);

            receiver.TakeDamage(wDamage);
            receiver.TakeDamage(pDamage);

            return [wDamage, pDamage];
        }

        private Damage RShot(Champion sender, Unit receiver)
        {
            int rank = sender.R.CurrentRank;

            double[] baseDamage = [5, 15, 25];
            double[] adScaling = [0.45, 0.45, 0.45];

            double preMitigationDamage = baseDamage[rank] + adScaling[rank] * sender.AD;

            Damage dmg = new(preMitigationDamage, DamageType.Physical, sender, receiver);

            receiver.TakeDamage(dmg);

            return dmg;
        }

        private Damage RShotCrit(Champion sender, Unit receiver)
        {
            int rank = sender.R.CurrentRank;

            double[] baseDamage = [5, 15, 25];
            double[] adScaling = [0.45, 0.45, 0.45];

            double preMitigationDamage =
                (baseDamage[rank] + adScaling[rank] * sender.AD) * sender.Stats["CritDamage"];

            Damage dmg = new(preMitigationDamage, DamageType.Physical, sender, receiver);

            receiver.TakeDamage(dmg);

            return dmg;
        }

        public Damage[] R(Champion sender, Unit receiver)
        {
            Damage[] dmg = new Damage[10];
            Random rnd = new();

            for (int shot = 0; shot < 10;  shot++)
            {
                if (rnd.Next(101) <= (int)(sender.Stats["CritChance"] * 100))
                {
                    dmg[shot] = RShotCrit(sender, receiver);
                } 
                else
                {
                    dmg[shot] = RShot(sender, receiver);
                }
            }

            return dmg;
        }
    }
}
