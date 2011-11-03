using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;

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

            using (var session = Program.factory.OpenSession())
            {
                var lb = session.CreateCriteria(typeof(Beverage)).List<Beverage>();
                

                foreach (Beverage b in lb)
                {
                    ListViewItem lvi = new ListViewItem(new string[] {
                        b.Name,
                        string.Format("{0} mL", b.Volume),
                        string.Format("{0:p}", b.PercentAlcohol/100.0),
                        string.Format("{0:0.0}", b.StandardDrinks),
                        "???",
                        "???",
                        b.IsEnabled ? "yes" : "no"
                    });

                    lvi.Tag = b;
                    lvBeverages.Items.Add(lvi);

                }
            }

            lvBeverages.EndUpdate();
            lvBeverages.Select();

        }

    }
}
