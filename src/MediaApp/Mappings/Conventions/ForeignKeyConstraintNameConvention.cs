using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace MediaApp.Mappings.Conventions
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