using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lloyd
{
    public partial class frmAddUser : Form
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
