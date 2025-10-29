using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Damage
    {
        public double PreMitigationDamage;
        public double PostMitigationDamage;
        public DamageType DamageType;
        public Unit Sender;
        public Unit Receiver;

        public Damage(double preMitigationDamage, DamageType damageType, Unit sender, Unit receiver)
        {
            PreMitigationDamage = preMitigationDamage;
            DamageType = damageType;
            Sender = sender;
            Receiver = receiver;
            SetPostMitigationDamage();
        }

        private void SetPostMitigationDamage()
        {
            if (DamageType == DamageType.True)
            {
                PostMitigationDamage = PreMitigationDamage;
            }
            else if (DamageType == DamageType.Physical)
            {
                double functionalResistance = Receiver.Armor *
                                        (1 - Sender.ArmorPen) - Sender.Lethality;
                PostMitigationDamage = GetPostMitigationDamage(PreMitigationDamage,
                                                        functionalResistance);
            }
            else if (DamageType == DamageType.Magical)
            {
                double functionalResistance = Receiver.MR *
                                        (1 - Sender.MagicPen) - Sender.FlatMagicPen;
                PostMitigationDamage = GetPostMitigationDamage(PreMitigationDamage,
                                                        functionalResistance);
            }
        }

        public double GetPostMitigationDamage(double rawDmg, double functionalResistance)
        {
            if(functionalResistance >= 0)
            {
                return rawDmg / (1 + (functionalResistance / 100));
            }
            else
            {
                return rawDmg * (2 - 100 / (100 - functionalResistance));
            }
        }
    }
}
