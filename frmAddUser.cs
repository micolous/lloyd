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
    partial class frmAddUser : Form
    {
        User u;
        bool newitem;

        public frmAddUser() : this(null) { }
        public frmAddUser(User u)
        {
            InitializeComponent();

            this.u = u;
            newitem = u == null;

            if (u != null)
            {
                txtName.Text = u.Name;
                chkAdmin.Checked = u.IsAdmin;
                chkBiologicallyMale.Checked = u.IsBiologicallyMale;
                nudHeight.Value = u.Height;
                nudWeight.Value = u.Weight;

            }



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
            btnAccept.Enabled = (txtName.Text.Length > 0 && (!newitem || string.IsNullOrEmpty(txtAccessKey.Text)));

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            // add the user to the system.
            try
            {
                using (var session = Program.factory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        if (u == null)
                        {
                            u = new User();
                            u.LastAccess = DateTime.MinValue;
                            u.IsEnabled = true;
                        }

                        u.Name = txtName.Text;
                        u.IsAdmin = chkAdmin.Checked;
                        u.Weight = (int)nudWeight.Value;
                        u.Height = (int)nudHeight.Value;
                        u.IsBiologicallyMale = chkBiologicallyMale.Checked;
                        if (!string.IsNullOrEmpty(txtAccessKey.Text)) {
                            u.EncodeAccessKey(txtAccessKey.Text);
                        }


                        session.SaveOrUpdate(u);

                        transaction.Commit();

                    }
                }

                //MessageBox.Show("Created user!");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("That username or access key is in use by another user.  Please check that this is not a duplicate and try again.");
            }



        }
    }
}
