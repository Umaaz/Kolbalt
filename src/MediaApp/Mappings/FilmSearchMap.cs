using FluentNHibernate.Search.Mapping;
using MediaApp.Domain.Model;

namespace MediaApp.Mappings
{
    public class FilmSearchMap : DocumentMap<Film>
    {
        protected override void Configure()
        {
            Id(x => x.Id).Bridge().Guid();
            Name("Film");

            Map(x => x.Title)
                .Index().Tokenized()
                .Store().Yes();

            Map(x => x.Synopsis)
                .Index().Tokenized()
                .Store().Yes();

            //Embedded(x => x.Director).AsCollection().Mappings(y => y.Map(z => z[0].Name));
            //Embedded(x => x.Director)
            //    .Mappings(m =>
            //        m.Map(a => a.Name)
            //            .Name("Director")
            //            .Index().Tokenized()
            //            .Store().Yes()
            //    );


            // Old fluent NH website, has more info: http://fnhsearch.codeplex.com/
            // If you wanna inspect what exactly is in the search index files, use this tool http://www.getopt.org/luke/
            Embedded(x => x.Cast).AsCollection();
        }
    }
}