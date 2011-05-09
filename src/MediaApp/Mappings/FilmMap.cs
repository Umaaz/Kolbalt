using FluentNHibernate.Mapping;
using MediaApp.Domain.Model;

namespace MediaApp.Mappings
{
    public class FilmMap : ClassMap<Film>
    {
        public FilmMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.IMDBId).Unique().Length(7);
            Map(x => x.PicURL).Length(263);
            Map(x => x.Title).Length(300);
            Map(x => x.RunTime);
            Map(x => x.ReleaseYear).Length(4);
            Map(x => x.FilmPath).Length(1000);
            Map(x => x.Synopsis).Length(4000);
            Map(x => x.OnExternalMedia);
            Map(x => x.TrailerLink).Length(263);
            Map(x => x.Keywords).Length(4000);

            HasMany(x => x.Writers).AsBag().Cascade.All();
            HasMany(x => x.Director).AsBag().Cascade.All();
            
            HasManyToMany(x => x.Genre)
                .AsBag()
                .Cascade.All();

            HasManyToMany(x => x.Cast)
                .AsBag()
                .Cascade.All();

            Map(x => x.DirectorIndexing).Length(4000);
            Map(x => x.CharIndexing).Length(4000);
            Map(x => x.GenreIndexing).Length(4000);
            Map(x => x.PersonIndexing).Length(4000);
        }
    }
}