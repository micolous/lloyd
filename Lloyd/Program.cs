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
using System.Windows.Forms;

namespace Lloyd
{
    static class Program
    {

        public static Database db;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // create a database connection
            try
            {
                db = new Database("lloyd.db3");
            }
            catch (ArgumentException)
            {
                MessageBox.Show(
                    "The database file probably contains data from a newer version of " +
                    "Lloyd, and is not schema-compatible.  Please upgrade Lloyd.",
                    "Lloyd", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }

            if (db.FirstRun)
            {
                // first run detected.
                MessageBox.Show("New database file created.  The initial account's access code is 0000.");

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
