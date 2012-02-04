using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;
using System.IO;
using System.Xml.Serialization;
using Lloyd.Database;
using System.Linq;

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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportDrinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // pick where to save.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Files (*.xml)|*.xml|All Files|*.*";
            sfd.DefaultExt = "xml";

            sfd.Title = "Where to save the exported data?";

            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // lets write the file.
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(BeverageDocument));
                BeverageDocument bd = new BeverageDocument();

                // get a list of beverages.
                using (var session = Program.factory.OpenSession())
                {
                    IList<Beverage> lb = session.CreateCriteria(typeof(Beverage)).List<Beverage>();
                    bd.Beverages = lb.ToArray<Beverage>();
                }

                xs.Serialize(fs, bd);

                fs.Flush();
                fs.Close();

                MessageBox.Show("File saved.");
                
            }

        }

        private void importDrinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // pick where to read from.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML Files (*.xml)|*.xml|All Files|*.*";
            ofd.DefaultExt = "xml";
            ofd.Title = "Where to read beverages to import?";

            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(BeverageDocument));

                BeverageDocument bd;
                try
                {
                    bd = (BeverageDocument)xs.Deserialize(fs);
                }
                catch (Exception)
                {
                    // TODO: improve this error.
                    MessageBox.Show("Error reading XML.  Is it the right format?");
                    fs.Close();
                    return;
                }

                fs.Close();

                // import into database.
                using (var session = Program.factory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (Beverage b in bd.Beverages)
                        {
                            b.IsEnabled = true;
                            session.SaveOrUpdate(b);
                        }
                        transaction.Commit();
                    }
                }

                RedrawDrinksList();
                MessageBox.Show(string.Format("Imported {0} beverage(s).", bd.Beverages.Length));
                
            }
        }

        private void addDrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: implement this properly.
            frmDrinkEditor f = new frmDrinkEditor();
            f.ShowDialog(this);
        }

    }
}
