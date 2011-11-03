using FluentNHibernate.Mapping;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Mappings
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