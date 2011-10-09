using FluentNHibernate.Mapping;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name).Length(300);
            Map(x => x.IMDBID).Unique().Length(7);
        }
    }
}