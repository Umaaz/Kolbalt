using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaApp.Domain
{
    public class Keyword
    {
        public virtual Guid Id { get; set; }
        public virtual String Word { get; set; }
    }
}
