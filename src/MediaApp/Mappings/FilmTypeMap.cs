using FluentNHibernate.Mapping;
using MediaApp.Domain.Model;

namespace MediaApp.Mappings
{
    public class FilmTypeMap : ClassMap<FilmType>
    {
        public FilmTypeMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Type).Unique();
        }
    }
}