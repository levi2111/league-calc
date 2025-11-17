using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abilities
{
    public class AbilityInput
    {
        Dictionary<string, int> CursorLocation = new Dictionary<string, int>
        {
            {"X", -1},
            {"Y", -1}
        };

        public AbilityInput(int cursorLocationX, int cursorLocationY)
        {
            CursorLocation["X"] = cursorLocationX;
            CursorLocation["Y"] = cursorLocationY;
        }
    }
}
