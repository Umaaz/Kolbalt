using System;

namespace MediaApp.Domain.Model
{
    public class Role
    {
        public virtual Guid Id { get; set; }
        public virtual string Character { get; set; }
        public virtual Person Person { get; set; }
    }
}