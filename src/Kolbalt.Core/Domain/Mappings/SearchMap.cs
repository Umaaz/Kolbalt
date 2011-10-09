using System.Reflection;
using FluentNHibernate.Search.Mapping;

namespace Kolbalt.Core.Domain.Mappings
{
    public class SearchMap : SearchMapping
	{
		protected override void Configure()
		{
			AddAssembly(Assembly.GetAssembly(typeof(SearchMap)));
		}
	}
}