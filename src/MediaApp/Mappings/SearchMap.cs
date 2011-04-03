using System.Reflection;
using FluentNHibernate.Search.Mapping;

namespace MediaApp.Mappings
{
    public class SearchMap : SearchMapping
	{
		protected override void Configure()
		{
			AddAssembly(Assembly.GetAssembly(typeof(SearchMap)));
		}
	}
}