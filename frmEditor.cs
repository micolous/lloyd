using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lloyd
{
    public partial class frmEditor : Form
    {
        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            RedrawDrinksList();
        }

        void RedrawDrinksList()
        {
            lvBeverages.BeginUpdate();
            lvBeverages.Items.Clear();
            lvBeverages.SelectedItems.Clear();
            

            IList<Beverage> lb = Program.db.GetAllBeverages();

            foreach (Beverage b in lb)
            {
                ListViewItem lvi = new ListViewItem(new string[] {
                    b.Name,
                    b.Volume + " mL",
                    b.PercentAlcohol + " %",
                    string.Format("{0,D.1}", b.StandardDrinks),
                    "???",
                    "???",
                    b.Enabled ? "yes" : "no"
                });

                lvi.Tag = b;
                lvBeverages.Items.Add(lvi);

            }
            lvBeverages.EndUpdate();
        }

    }
}
