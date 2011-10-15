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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lloyd
{
    partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Revalidate();
        }

        private void txtAccessKey_TextChanged(object sender, EventArgs e)
        {
            Revalidate();
        }


        void Revalidate()
        {
            btnAccept.Enabled = (txtName.Text.Length > 0 && txtAccessKey.Text.Length > 0);

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // add the user to the system.
            try
            {
                Program.db.CreateUser(txtName.Text, txtAccessKey.Text, chkAdmin.Checked);

                MessageBox.Show("Created user!");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input?  Couldn't add the user");
            }
        }
    }
}
