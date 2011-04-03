using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaApp.Data
{
    class ListViewItem
    {
        private String _actor { get; set; }
        private String _Character { get; set; }
        private Guid Id { get; set; }
        
        public ListViewItem(Guid id, String actor, String character)
        {
            _actor = actor;
            Id = id;
            _Character = character;
        }

        public override string ToString()
        {
            return "";// Hours + ":" + Mins;
        }
    }
}
