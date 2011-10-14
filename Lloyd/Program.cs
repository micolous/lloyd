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
            db = new Database("lloyd.db3");

            if (db.FirstRun)
            {
                // first run detected.
                MessageBox.Show("The initial account's access code is 0000.");

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
