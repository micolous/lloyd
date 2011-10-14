using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lloyd
{
    public partial class frmLogin : Form
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
                User u = Program.db.LoginUser(txtAccessCard.Text);

                if (u == null)
                {
                    // invalid login.
                    txtAccessCard.Text = "";
                }
                else
                {
                    // valid login.  launch interface.
                    txtAccessCard.Text = "";

                    frmDashboard f = new frmDashboard(u);
                    Hide();
                    f.ShowDialog(this);
                    Show();
                    
                }
            }
        }

    }
}
