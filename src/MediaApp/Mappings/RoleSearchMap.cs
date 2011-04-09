using FluentNHibernate.Search.Mapping;
using MediaApp.Domain;

namespace MediaApp.Mappings
{
    public class RoleSearchMap : DocumentMap<Role>
    {
        protected override void Configure()
        {
            Id(x => x.Id).Bridge().Guid();
            Name("Role");

            Map(x => x.Character)
                .Index().Tokenized()
                .Store().Yes();

            Embedded(x => x.Person)
                .Mappings(m =>
                    m.Map(a => a.Name)
                        .Name("Actor")
                        .Index().Tokenized()
                        .Store().Yes()
                );
        }
    }
}