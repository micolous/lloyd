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
        public frmDashboard(User u)
        {
            InitializeComponent();

            lblWelcome.Text = string.Format(lblWelcome.Text, u.name);

            btnUserManager.Enabled = u.admin;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
