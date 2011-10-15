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
            
            IList<User> lu = Program.db.GetAllUsers();
            foreach (User u in lu) {
                DateTime lastAccessLocal = u.LastAccess.ToLocalTime();

                ListViewItem lvi = new ListViewItem(new string[] {
                    u.name,
                    lastAccessLocal.ToShortDateString() + " " + lastAccessLocal.ToShortTimeString(),
                    u.admin ? "yes" : "no",
                    u.enabled ? "yes" : "no"
                });

                lvi.Tag = u;
                lvUserList.Items.Add(lvi);
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
                Program.db.RenameUser(GetSelectedUser().id, txtRenameUser.Text);
                RedrawUserList();
                
            }
        }

        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            Program.db.SetUserAdministrator(u.id, !u.admin);
            RedrawUserList();
        }

        private void disableAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User u = GetSelectedUser();
            Program.db.SetUserEnabled(u.id, !u.enabled);
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
                    Program.db.ChangeAccessKey(GetSelectedUser().id, txtChangeAccessCard.Text);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("That access key is in use by another user.");
                }
                RedrawUserList();

            }
        }

    }
}
