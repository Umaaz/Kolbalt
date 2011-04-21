using FluentNHibernate.Mapping;
using MediaApp.Domain;

namespace MediaApp.Mappings
{
    public class FilmMap : ClassMap<Film>
    {
        public FilmMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.IMDBId).Unique();
            Map(x => x.PicURL);
            Map(x => x.Title);
            Map(x => x.RunTime);
            Map(x => x.ReleaseYear);
            Map(x => x.FilmPath);
            Map(x => x.Synopsis).Length(4000);
            Map(x => x.Keywords);
            References(x => x.Director).Cascade.All(); 

            HasManyToMany(x => x.Genre)
                .AsBag()
                .Cascade.All();

            HasManyToMany(x => x.Cast)
                .AsBag()
                .Cascade.All();
        }
    }
}