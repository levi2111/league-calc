using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnit
    {
        int Level { get; }
        double HP { get; }
        IStats Stats { get; set; }
    }
}
