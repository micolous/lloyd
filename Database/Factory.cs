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
using System.IO;


namespace Lloyd.Database
{
    public class Factory
    {
        /// <summary>
        /// An ISessionFactory for interacting with NHiberate with.
        /// </summary>
        public ISessionFactory SessionFactory { get; private set; }

        /// <summary>
        /// Was the database created by this factory, or did it already exist?
        /// </summary>
        public bool DatabaseCreated { get; private set; }
        private string databaseFilename = string.Empty;

        public Factory(string filename)
        {
            databaseFilename = filename;
            DatabaseCreated = false;

            SessionFactory =
             Fluently.Configure()
                .Database(
                  SQLiteConfiguration.Standard
                    .UsingFile(filename)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Factory>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            if (DatabaseCreated)
                PopulateInitialData();
        }

        private void BuildSchema(Configuration config)
        {
            if (!File.Exists(databaseFilename))
            {
                DatabaseCreated = true;
                // The database file doesn't already exist, so we have to create the
                // schema for it.
                new SchemaExport(config).Create(false, true);
            }
        }


        private void PopulateInitialData()
        {
            using (var session = SessionFactory.OpenSession())
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

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
