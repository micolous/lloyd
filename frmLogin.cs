/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011-2012 Michael Farrell <http://micolous.id.au/>.
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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;

namespace Lloyd
{
    partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtAccessCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;

                // attempt to handle the event.
                User u = Database.Entities.User.GetUserByAccessKey(Program.factory.SessionFactory, txtAccessCard.Text);
                
                txtAccessCard.Text = "";
                if (u != null && u.IsEnabled)
                {
                    // valid login.  launch interface.
                    txtAccessCard.Text = "";

                    frmDashboard f = new frmDashboard(u);
                    Hide();
                    f.ShowDialog(this);
                    Show();

                }
                else
                {
                    // TODO: implement some feedback mechanism for failed logins

                }
            }
        }



    }
}
