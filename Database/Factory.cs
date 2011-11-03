using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Lloyd.Database.Entities;


namespace Lloyd.Database
{
    public class Factory
    {
        public static ISessionFactory CreateSessionFactory(string filename)
        {
            return Fluently.Configure()
                .Database(
                  SQLiteConfiguration.Standard
                    .UsingFile(filename)
                )
                .Mappings(m =>
                  m.FluentMappings.AddFromAssemblyOf<Factory>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

        }

        private static void BuildSchema(Configuration config)
        {

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }

        public static bool HasUsers(ISessionFactory factory)
        {
            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    var users = session.CreateCriteria(typeof(User)).List<User>();

                    return users.Count > 0;
                }
            }
        }

        public static void PopulateInitialData(ISessionFactory factory)
        {
            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var adminUser = new User { Name = "admin", IsEnabled = true, IsAdmin = true, LastAccess = DateTime.Now };
                    adminUser.EncodeAccessKey("0000");
                    session.SaveOrUpdate(adminUser);

                    transaction.Commit();
                }
            }
        }
    }
}
