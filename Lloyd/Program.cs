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
