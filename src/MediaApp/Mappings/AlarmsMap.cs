
using FluentNHibernate.Mapping;
using MediaApp.Domain;
using MediaApp.Domain.Model;

namespace MediaApp.Mappings
{
    public class AlarmsMap : ClassMap<Alarms>
    {
        public AlarmsMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Hours);
            Map(x => x.Mins);
        }
    }
}