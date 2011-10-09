using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Search;
using FluentNHibernate.Search.Cfg;
using Kolbalt.Core.Domain.Mappings;
using Kolbalt.Core.Domain.Model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Kolbalt.Core.Data
{
    public class NhContext
    {
        private static ISession _session;
        private static ISessionFactory _sessionFactory;

        public static ISession GetSession()
        {
            return _session ?? (_session = _sessionFactory.OpenSession());
        }

        public static void Bootstrap(string appPath, string cnxString)
        {
            var dbPath = appPath + "\\Media.sdf";
            var configuration = Fluently.Configure()
                        .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(cnxString))
                            .Search(s =>
                                s.DefaultAnalyzer().Standard()
                                .DirectoryProvider().FSDirectory()
                                .IndexBase(appPath + "\\SearchIndex")
                                .IndexingStrategy().Event()
                                .Listeners(ListenerConfiguration.Default)
                                .MappingClass<SearchMap>()
                            )
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Film>()
                        .Conventions.AddFromAssemblyOf<Film>()
                        );

            if (!File.Exists(dbPath))
            {
                var engine = new System.Data.SqlServerCe.SqlCeEngine(cnxString);
                engine.CreateDatabase();

                configuration.ExposeConfiguration(c => new SchemaExport(c).Create(false, true));
            }
            _sessionFactory = configuration.BuildSessionFactory();
        }

        private static void BuildSchema(Configuration cfg)
        {
            new SchemaExport(cfg).Create(false, true);
        }
    }
}