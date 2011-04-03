using System;

namespace MediaApp.Data
{
    class AlarmListViewItem
    {
        private int Hours { get; set; }
        private int Mins { get; set; }
        private Guid Id { get; set; }
        
        public AlarmListViewItem(Guid id, int hours, int mins)
        {
            Hours = hours;
            Id = id;
            Mins = mins;
        }

        public override string ToString()
        {
            return Hours + ":" + Mins;
        }
    }
}
