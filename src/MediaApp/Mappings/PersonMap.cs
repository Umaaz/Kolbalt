using FluentNHibernate.Mapping;
using MediaApp.Domain;

namespace MediaApp.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.IMDBID).Unique();
        }
    }
}