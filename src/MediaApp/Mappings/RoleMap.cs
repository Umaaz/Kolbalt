using FluentNHibernate.Mapping;
using MediaApp.Domain.Model;

namespace MediaApp.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Character);
            References(x => x.Person).Cascade.All();
        }
    }
}