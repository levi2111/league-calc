using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class FormatterService
    {
        public static string GetCDragonChampionName(string championName)
        {
            string noSpaces = championName.Replace(" ", "");
            string noApostrophes = championName.Replace("'", "");

            return noApostrophes;
        }
    }
}
