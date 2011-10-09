using System;

namespace Kolbalt.Core.Domain.Model
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IMDBID { get; set; }
    }
}