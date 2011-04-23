using System;

namespace MediaApp.Domain.Model
{
    public class FilmType
    {
        public virtual Guid Id { get; set; }
        public virtual string Type { get; set; }
    }
}