using System;

namespace MediaApp.Domain
{
    public class Role
    {
        public virtual Guid Id { get; set; }
        public virtual string Character { get; set; }
        public virtual Person Person { get; set; }
    }
}