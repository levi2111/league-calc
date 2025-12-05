using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Config
    {
        // make these non nullable later
        public string ID { get; set; }
        public string ChampionName { get; set; }
        public string? Patch { get; set; }
        public List<int>? ItemIDs { get; set; }
        public int Level { get; set; }
        public int? QRank { get; set; }
        public int? WRank { get; set; }
        public int? ERank { get; set; }
        public int? RRank { get; set; }

        public Config()
        {
            ID = new Random().Next(0, 100000000).ToString();
        }
    }
}
