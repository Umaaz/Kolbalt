﻿using FluentNHibernate.Mapping;
using FluentNHibernate.Search.Mapping;
using MediaApp.Domain;

namespace MediaApp.Mappings
{
    public class FilmMap : ClassMap<Film>
    {
        public FilmMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.ImdbId).Unique();
            Map(x => x.Title);
            Map(x => x.RunTime);
            Map(x => x.ReleaseDate);
            Map(x => x.FilmPath);
            Map(x => x.Synopsis).Length(4000);
            References(x => x.Director).Cascade.All(); //is this right then?

                //nice and simple now, you hope.. need to rebuild db tho

            //you can override the conventions by specfying stuff in this classmaps, alright.

            //HasManyToMany(x=>x.Director)
            //    .AsBag()
            //    .Cascade.All();
            
            HasManyToMany(x => x.Keywords)
                .AsBag()
                .Cascade.All();

            HasManyToMany(x => x.Genre)
                .AsBag()
                .Cascade.All();

            HasManyToMany(x => x.Cast)
                .AsBag()
                .Cascade.All();
        }
    }

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

            Embedded(x => x.Director)
                .Mappings(m =>
                    m.Map(a => a.Name)
                        .Name("Director")
                        .Index().Tokenized()
                        .Store().Yes()
                );
        }
    }
}