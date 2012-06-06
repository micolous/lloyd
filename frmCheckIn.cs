using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;
using NHibernate.Criterion;
using NHibernate;

namespace Lloyd
{
    public partial class frmCheckIn : Form
    {
        User currentUser;
        BindingSource bsStockStatus;

        public frmCheckIn(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;

            bsStockStatus = new BindingSource();
            RefreshStockStatus();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtCheckinBarcode.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            nudCost.Focus();
        }

        private void txtCheckinBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;

                // lookup drink
                Sku s = Sku.GetSkuByBarcode(Program.factory.SessionFactory, txtCheckinBarcode.Text);

                if (s == null)
                {
                    MessageBox.Show(this, "Unknown item scanned: " + txtCheckinBarcode.Text, "Lloyd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!s.IsEnabled)
                {
                    MessageBox.Show(this, "Disabled item scanned: " + txtCheckinBarcode.Text, "Lloyd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // add stock.
                    // create transaction
                    using (var session = Program.factory.OpenSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {

                            DateTime now = DateTime.Now;
                            for (int x = 0; x < s.Quantity; x++)
                            {
                                Stock k = new Stock
                                {
                                    Beverage = s.Beverage,
                                    AddedAt = now,
                                    Cost = (uint)(nudCost.Value * 100),
                                    Owner = currentUser,
                                    RequiresPermission = chkRequiresPermission.Checked
                                };


                                session.Save(k);
                            }

                            transaction.Commit();

                            lblLastScanStatus.Text = string.Format(
                                "Added {0} unit(s) of {1} to your stock at {2:C}.",
                                s.Quantity,
                                s.Beverage.Name,
                                nudCost.Value
                            );

                            RefreshStockStatus();
                        }
                    }
                }
                txtCheckinBarcode.Text = "";
            }
        }

        private void RefreshStockStatus()
        {
            using (var session = Program.factory.OpenSession()) {
                var ssl = session.CreateCriteria(typeof(Stock))
                    .Add(Restrictions.Eq("Owner", currentUser))
                    .SetFetchMode("Beverage", FetchMode.Eager)
                    .SetFetchMode("Owner", FetchMode.Eager)
                    .SetFetchMode("Consumer", FetchMode.Eager)
                    .List<Stock>();
                bsStockStatus.DataSource = ssl;
                dgvStockStatus.DataSource = bsStockStatus;

                foreach (DataGridViewColumn column in dgvStockStatus.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    if (column.HeaderText == "Owner")
                        column.Visible = false;
                    if (column.HeaderText == "RequiresPermission")
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                
                }
            
            }
        }
    }
}
