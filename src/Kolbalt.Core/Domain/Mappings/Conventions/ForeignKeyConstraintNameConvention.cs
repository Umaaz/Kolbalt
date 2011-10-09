using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Kolbalt.Core.Domain.Mappings.Conventions
{
    public class ForeignKeyConstraintNameConvention : IHasManyConvention //IHasBucket!
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
//we need to config it
            instance.Key.ForeignKey(string.Format("FK_{0}_{1}", instance.EntityType.Name, instance.Member.Name));
        }
    }
}