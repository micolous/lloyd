using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lloyd.Database.Entities;

namespace Lloyd
{
    public partial class frmDrinkEditor : Form
    {
        public frmDrinkEditor() : this(null) { }

        Beverage b;
        bool create_mode;

        public frmDrinkEditor(Beverage b )
        {
            InitializeComponent();
            cboAlcoholMode.SelectedIndex = 0;

            this.b = b;

            create_mode = (this.b == null);
            groupSKU.Enabled = !create_mode;

            if (create_mode)
            {
                this.b = new Beverage();


            }
            else
            {
                txtName.Text = this.b.Name;
                nudVolume.Value = (decimal)this.b.Volume;
                nudAlcohol.Value = (decimal)this.b.PercentAlcohol;

                skuBindingSource.Filter = string.Format("Beverage = '{0}'", this.b.Id);
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
        }
    }
}
