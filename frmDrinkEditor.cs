using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lloyd
{
    public partial class frmDrinkEditor : Form
    {
        public frmDrinkEditor()
        {
            InitializeComponent();
            cboAlcoholMode.SelectedIndex = 0;

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
                    break;

                case 1: // grams
                    // cap alcohol content at the maximum number of grams of alcohol.
                    nudAlcohol.Maximum = (decimal)StandardDrink.alcohol_density_g_ml * nudVolume.Value;
                    break;

                case 2: // mL
                    // cap alcohol content at the volume
                    nudAlcohol.Maximum = nudVolume.Value;

                    break;

                case 3: // standard drinks
                    // cap alcohol content at the volume.
                    nudAlcohol.Maximum = (decimal)StandardDrink.GetForCurrentLocale().StandardDrinksByVolumeAlcohol((double)nudVolume.Value);

                    break;
            }

            if (nudAlcohol.Value > nudAlcohol.Maximum)
                nudAlcohol.Value = nudAlcohol.Maximum;
        }

        private void nudVolume_ValueChanged(object sender, EventArgs e)
        {
            CalculateAlcoholBounds();
        }
    }
}
