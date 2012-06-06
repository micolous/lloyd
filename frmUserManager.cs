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
    partial class frmUserManager : Form
    {
        public frmUserManager()
        {
            InitializeComponent();
        }

        private void frmUserManager_Load(object sender, EventArgs e)
        {
            RedrawUserList();
        }


        private void RedrawUserList()
        {
            lvUserList.BeginUpdate();
            lvUserList.Items.Clear();
            lvUserList.SelectedItems.Clear();

            using (var session = Program.factory.OpenSession())
            {
                var lu = session.CreateCriteria(typeof(User)).List<User>();
                foreach (User u in lu)
                {
                    ListViewItem lvi = new ListViewItem(new string[] {
                        u.Name,
                        u.LastAccess.ToShortDateString() + " " + u.LastAccess.ToShortTimeString(),
                        u.IsAdmin ? "yes" : "no",
                        u.IsEnabled ? "yes" : "no"
                    });

                    lvi.Tag = u;
                    lvUserList.Items.Add(lvi);
                }
            }


            lvUserList.EndUpdate();
            lvUserList.Select();
            lvUserList_SelectedIndexChanged(lvUserList, null);
        }

        private User GetSelectedUser()
        {
            return ((User)lvUserList.SelectedItems[0].Tag);
        }


        private void txtRenameUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && txtRenameUser.Text.Length > 0)
            {
                e.Handled = true;

                // rename the user
                var u = GetSelectedUser();
                using (var session = Program.factory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        u.Name = txtRenameUser.Text;
                        session.SaveOrUpdate(u);
                        transaction.Commit();
                    }
                }

                RedrawUserList();
                
            }
        }

        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            editUserToolStripMenuItem.Enabled = 
                changeUserToolStripMenuItem.Enabled = (lvUserList.SelectedItems.Count == 1);
            changeUserToolStripMenuItem.HideDropDown();

            if (lvUserList.SelectedItems.Count == 1)
            {
                // update edit fields.
                txtRenameUser.Text = lvUserList.SelectedItems[0].SubItems[0].Text;

            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser f = new frmAddUser();
            f.ShowDialog(this);
            RedrawUserList();
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User u = GetSelectedUser();
            
            using (var session = Program.factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    u.IsAdmin = !u.IsAdmin;
                    session.SaveOrUpdate(u);
                    transaction.Commit();
                }
            }

            RedrawUserList();
        }

        private void disableAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User u = GetSelectedUser();
            using (var session = Program.factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    u.IsEnabled = !u.IsEnabled;
                    session.SaveOrUpdate(u);
                    transaction.Commit();
                }
            }
            RedrawUserList();
        }

        private void txtChangeAccessCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && txtChangeAccessCard.Text.Length > 0)
            {
                e.Handled = true;

                // rename the user
                try
                {
                    User u = GetSelectedUser();
                    using (var session = Program.factory.OpenSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            u.EncodeAccessKey(txtChangeAccessCard.Text);
                            session.SaveOrUpdate(u);
                            transaction.Commit();
                        }
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("That access key is in use by another user.");
                }
                RedrawUserList();

            }
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User u = GetSelectedUser();
            frmAddUser f = new frmAddUser(u);
            f.ShowDialog(this);
            RedrawUserList();
        }

    }
}
