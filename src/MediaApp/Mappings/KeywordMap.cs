using FluentNHibernate.Mapping;
using MediaApp.Domain;

namespace MediaApp.Mappings
{
    public class KeywordMap : ClassMap<Keyword>
    {
        public KeywordMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Word).Unique();
        }
    }
}