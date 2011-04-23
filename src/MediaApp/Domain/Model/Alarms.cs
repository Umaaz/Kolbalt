using System;

namespace MediaApp.Domain.Model
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