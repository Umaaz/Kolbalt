using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaApp.Domain
{
    public class Alarms
    {
        public virtual Guid Id { get; set; }
        public virtual int Hours { get; set; }
        public virtual int Mins { get; set; }

        public override string ToString()
        {
            return Hours + ":" + Mins;
        }
    }
}
