/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011-2012 Michael Farrell <http://micolous.id.au/>.
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;
using NHibernate.Criterion;
using NHibernate;

namespace Lloyd
{
    public partial class frmDrinkEditor : Form
    {
        public frmDrinkEditor() : this(null) { }

        Beverage b;
        bool create_mode;
        ISession session = Program.factory.OpenSession();
        ITransaction transaction;
        bool saved = true;
        BindingSource bsSKU = null;

        public frmDrinkEditor(Beverage b )
        {
            InitializeComponent();
            cboAlcoholMode.SelectedIndex = 0;

            this.session.FlushMode = FlushMode.Commit;
            this.transaction = this.session.BeginTransaction();
            this.b = b;

            create_mode = (this.b == null);
            groupSKU.Enabled = !create_mode;

            if (create_mode)
            {
                this.b = new Beverage();
                this.b.IsEnabled = true;

                // hide skus because we can't create them until an object exists.
                dgvSKUs.Enabled = dgvSKUs.Visible = groupSKU.Visible = groupSKU.Enabled = false;
                Height -= groupSKU.Height;

                Text = String.Format(Text, "New Drink");
            }
            else
            {
                txtName.Text = this.b.Name;
                nudVolume.Value = (decimal)this.b.Volume;
                nudAlcohol.Value = (decimal)this.b.PercentAlcohol;

                bsSKU = new BindingSource();

                var ls = session.CreateCriteria(typeof(Sku))
                    .Add(Restrictions.Eq("Beverage", this.b))
                    .List<Sku>();
                bsSKU.DataSource = ls;
                bsSKU.AllowNew = true;

                //bsSKU.ListChanged += new ListChangedEventHandler(bsSKU_ListChanged);
                bsSKU.CurrentChanged += new EventHandler(bsSKU_CurrentChanged);
                
                
                dgvSKUs.DataSource = bsSKU;
                skuBindingSource.Filter = string.Format("Beverage = '{0}'", this.b.Id);
                Text = String.Format(Text, this.b.Name + " (" + this.b.Id + ")");
            }

            saved = true;

        }

        void bsSKU_CurrentChanged(object sender, EventArgs e)
        {
            BindingSource o = (BindingSource)sender;
            if (o.Current != null)
            {
                Sku s = (Sku)o.Current;
                s.Beverage = this.b;
                saved = false;
            }
        }


        private void cboAlcoholMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAlcoholBounds();
        }


        private void CalculateAlcoholBounds()
        {
            nudAlcohol.Minimum = 0;

            switch (cboAlcoholMode.SelectedIndex)
            {
                case 0: // percent
                    nudAlcohol.Maximum = 100;
                    nudAlcohol.DecimalPlaces = 2;
                    if (b != null)
                        nudAlcohol.Value = (decimal)b.PercentAlcohol;
                    break;

                case 1: // grams
                    // cap alcohol content at the maximum number of grams of alcohol.
                    nudAlcohol.Maximum = (decimal)StandardDrink.alcohol_density_g_ml * nudVolume.Value;
                    nudAlcohol.DecimalPlaces = 0;
                    if (b != null)
                        nudAlcohol.Value = (decimal)b.MassAlcohol;
                    break;

                case 2: // mL
                    // cap alcohol content at the volume
                    nudAlcohol.Maximum = nudVolume.Value;
                    nudAlcohol.DecimalPlaces = 0;
                    if (b != null)
                        nudAlcohol.Value = (decimal)b.VolumeAlcohol;
                    break;

                case 3: // standard drinks
                    // cap alcohol content at the volume.
                    nudAlcohol.Maximum = (decimal)StandardDrink.GetForCurrentLocale().StandardDrinksByVolumeAlcohol((double)nudVolume.Value);
                    nudAlcohol.DecimalPlaces = 1;
                    if (b != null)
                        nudAlcohol.Value = (decimal)b.StandardDrinks;
                    break;
            }

            if (nudAlcohol.Value > nudAlcohol.Maximum)
                nudAlcohol.Value = nudAlcohol.Maximum;
        }

        private void nudVolume_ValueChanged(object sender, EventArgs e)
        {
            CalculateAlcoholBounds();
            b.Volume = (long)nudVolume.Value;
            saved = false;
        }

        private void frmDrinkEditor_Load(object sender, EventArgs e)
        {

        }

        private void nudAlcohol_ValueChanged(object sender, EventArgs e)
        {

            switch (cboAlcoholMode.SelectedIndex)
            {
                case 0: // percent
                    b.PercentAlcohol = (double)nudAlcohol.Value;
                    break;

                case 1: // grams
                    b.MassAlcohol = (double)nudAlcohol.Value;
                    break;

                case 2: // mL
                    b.VolumeAlcohol = (double)nudAlcohol.Value;
                    break;

                case 3: // standard drinks
                    b.StandardDrinks = (double)nudAlcohol.Value;
                    break;
            }
            saved = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // name isn't populated onto the object automatically.
            txtName.Text = txtName.Text.Trim();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show(this, "You must enter a name for the beverage.", "Lloyd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.b.Name = txtName.Text;

            // save it.
            session.SaveOrUpdate(this.b);
            
            // save skus
            if (bsSKU != null) {

                LinkedList<int> currentSKUIDs = new LinkedList<int>();

                foreach (Sku s in bsSKU.List)
                {   
                    try
                    {
                        session.SaveOrUpdate(s);
                        currentSKUIDs.AddLast(s.Id);
                    }
                    catch (NHibernate.Exceptions.GenericADOException ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        session.Close();
                        session = Program.factory.OpenSession();

                        // restart transaction
                        this.transaction = this.session.BeginTransaction();

                        MessageBox.Show(this, string.Format("Error while saving SKU {0}:\r\n{1}", s.Barcode, ex.InnerException.Message), "Lloyd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // delete SKUs not in the list.
                var ls = session.CreateCriteria(typeof(Sku))
                 .Add(Restrictions.Eq("Beverage", this.b))
                 .Add(Restrictions.Not(Restrictions.In("Id", currentSKUIDs)))
                 .List<Sku>();
                
                foreach (var dob in ls)
                    session.Delete(dob);
            }

            


            // commit transaction
            transaction.Commit();
            transaction = null;
            saved = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDrinkEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && MessageBox.Show(this, "Are you sure you want to cancel?  Unsaved changes will be lost.", "Lloyd", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;

            }
            session.Close();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void dgvSKUs_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Quantity"].Value = 1;
            e.Row.Cells["Enabled"].Value = true;
        }
    }
}
