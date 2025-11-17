using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Effects
{
    public abstract class Effect
    {
        public TimeSpan Duration { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime End
        {
            get
            {
                return Start + Duration;
            }
        }

        public Effect(TimeSpan duration, DateTime start)
        {
            Duration = duration;
            Start = start;
        }

        // delegate to handle effect logic maybe?
    }
}
