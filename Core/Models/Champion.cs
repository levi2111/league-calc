using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Champion : Unit
    {
        private BaseChampion BaseChampion { get; set; }
        public int Level {  get; set; }
        public IStats Stats { get; set; }
        public Ability Q { get; set; }
        public Ability W { get; set; }
        public Ability E { get; set; }
        public Ability R { get; set; }
        public Inventory Inventory { get; }
        public Champion(BaseChampion baseChampion)
        {
            BaseChampion = baseChampion;
            Inventory = new Inventory();
        }
    }
}
