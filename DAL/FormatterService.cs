using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FormatterService
    {
        public FormatterService() { }

        public string GetCDragonChampionName(string championName)
        {
            string noSpaces = championName.Replace(" ", "");
            string noApostrophes = championName.Replace("'", "");

            return noApostrophes;
        }
    }
}
