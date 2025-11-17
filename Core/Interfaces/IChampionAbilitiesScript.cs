using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IChampionAbilitiesScript
    {
        Damage GetQDamage(Champion sender, Unit receiver);
        Damage ApplyQDamage(Champion sender, Unit receiver);
        Damage GetWDamage(Champion sender, Unit receiver);
        Damage ApplyWDamage(Champion sender, Unit receiver);
        Damage GetEDamage(Champion sender, Unit receiver);
        Damage ApplyEDamage(Champion sender, Unit receiver);
        Damage GetRDamage(Champion sender, Unit receiver);
        Damage ApplyRDamage(Champion sender, Unit receiver);
    }
}
