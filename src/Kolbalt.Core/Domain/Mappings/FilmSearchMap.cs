using FluentNHibernate.Search.Mapping;
using Kolbalt.Core.Domain.Model;

namespace Kolbalt.Core.Domain.Mappings
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

                Map(x => x.Keywords)
                    .Index().Tokenized()
                    .Store().Yes();

                Map(x => x.Synopsis)
                    .Index().Tokenized()
                    .Store().Yes();

                Map(x => x.PersonIndexing)
                    .Index().Tokenized()
                    .Store().Yes();

                Map(x => x.CharIndexing)
                    .Index().Tokenized()
                    .Store().Yes();

                Map(x => x.GenreIndexing)
                    .Index().Tokenized()
                    .Store().Yes();

                Map(x => x.DirectorIndexing)
                    .Index().Tokenized()
                    .Store().Yes();


            
            // Old fluent NH website, has more info: http://fnhsearch.codeplex.com/
            // If you wanna inspect what exactly is in the search index files, use this tool http://www.getopt.org/luke/
            //Embedded(x => x.Cast).AsCollection();
        }
    }
}