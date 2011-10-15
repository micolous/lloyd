using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lloyd
{
    partial class frmDashboard : Form
    {
        bool admin;
        public frmDashboard(User u)
        {
            InitializeComponent();

            lblWelcome.Text = string.Format(lblWelcome.Text, u.name);

            admin = u.admin;

            btnUserManager.Enabled = admin;
            btnUserManager.Visible = admin;
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
    }
}
