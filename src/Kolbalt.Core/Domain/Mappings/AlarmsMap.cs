using FluentNHibernate.Mapping;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Mappings
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