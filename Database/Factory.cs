/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011 Michael Farrell <http://micolous.id.au/>.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */


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
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Factory>())
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

                    var testBeverage = new Beverage { Name = "Example Beer", IsEnabled = true, PercentAlcohol = 4.5, Volume = 375 };
                    session.SaveOrUpdate(testBeverage);

                    transaction.Commit();
                }
            }
        }
    }
}
