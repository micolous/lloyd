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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;

namespace Lloyd
{
    partial class frmDashboard : Form
    {
        bool admin;
        User u;
        public frmDashboard(User u)
        {
            InitializeComponent();

            lblWelcome.Text = string.Format(lblWelcome.Text, u.Name);
            this.u = u;
            admin = u.IsAdmin;

            btnUserManager.Enabled = admin;
            btnUserManager.Visible = admin;

            btnEditor.Enabled = admin;
            btnEditor.Visible = admin;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                frmUserManager f = new frmUserManager();
                f.ShowDialog(this);
            }
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                frmEditor f = new frmEditor();
                f.ShowDialog(this);
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;

                // lookup drink
                Sku s = Sku.GetSkuByBarcode(Program.factory.SessionFactory, txtBarcode.Text);

                if (s == null)
                {
                    lblScannedDrink.Text = "Unknown item " + txtBarcode.Text;
                }
                else if (!s.IsEnabled)
                {
                    lblScannedDrink.Text = "Disabled item " + txtBarcode.Text;
                }
                else
                {
                    lblScannedDrink.Text = string.Format("{0} unit(s) of {1}, {2} mL",
                        s.Quantity,
                        s.Beverage.Name,
                        s.Beverage.Volume
                    );


                }
                txtBarcode.Text = "";
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            frmCheckIn f = new frmCheckIn(u);
            f.ShowDialog(this);

        }
    }
}
