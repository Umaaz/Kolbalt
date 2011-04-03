using System;
using FluentNHibernate.Mapping;

namespace MediaApp.Domain
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string imdbID { get; set; }
        //dob
        //bio?
        //place of birth
        //picture, or link to picture..
        //link to imdb page..can Id be replaced with imdb number..
    }
}