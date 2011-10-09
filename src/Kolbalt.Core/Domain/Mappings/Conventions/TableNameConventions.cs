using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Kolbalt.Core.Domain.Mappings.Conventions
{
    public class TableNameConvention : IClassConvention, IClassConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IClassInspector> criteria)
        {
            criteria.Expect(x => x.TableName, Is.Not.Set);
        }

        public void Apply(IClassInstance instance)
        {
            //Adding a prefix so we don't get keyword conflicts i.e. 'cast'
            instance.Table("tbl_" + instance.EntityType.Name);
        }
    }

    public class CustomManyToManyTableNameConvention : ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide)
        {
            return collection.EntityType.Name + "_" + otherSide.EntityType.Name;
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return collection.EntityType.Name + "_" + collection.ChildType.Name;
        }
    }
}