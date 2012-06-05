namespace Lloyd
{
    partial class frmDrinkEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudAlcohol = new System.Windows.Forms.NumericUpDown();
            this.lblAlcohol = new System.Windows.Forms.Label();
            this.cboAlcoholMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupSKU = new System.Windows.Forms.GroupBox();
            this.dgvSKUs = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.skuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlcohol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            this.groupSKU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSKUs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nudAlcohol);
            this.groupBox1.Controls.Add(this.lblAlcohol);
            this.groupBox1.Controls.Add(this.cboAlcoholMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudVolume);
            this.groupBox1.Controls.Add(this.lblVolume);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drink Properties";
            // 
            // nudAlcohol
            // 
            this.nudAlcohol.DecimalPlaces = 2;
            this.nudAlcohol.Location = new System.Drawing.Point(89, 72);
            this.nudAlcohol.Name = "nudAlcohol";
            this.nudAlcohol.Size = new System.Drawing.Size(99, 20);
            this.nudAlcohol.TabIndex = 7;
            this.nudAlcohol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAlcohol.ValueChanged += new System.EventHandler(this.nudAlcohol_ValueChanged);
            // 
            // lblAlcohol
            // 
            this.lblAlcohol.AutoSize = true;
            this.lblAlcohol.Location = new System.Drawing.Point(41, 74);
            this.lblAlcohol.Name = "lblAlcohol";
            this.lblAlcohol.Size = new System.Drawing.Size(42, 13);
            this.lblAlcohol.TabIndex = 6;
            this.lblAlcohol.Text = "&Alcohol";
            // 
            // cboAlcoholMode
            // 
            this.cboAlcoholMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlcoholMode.FormattingEnabled = true;
            this.cboAlcoholMode.Items.AddRange(new object[] {
            "Percent",
            "Grams Ethanol",
            "Millilitres Ethanol",
            "Standard Drinks"});
            this.cboAlcoholMode.Location = new System.Drawing.Point(197, 71);
            this.cboAlcoholMode.Name = "cboAlcoholMode";
            this.cboAlcoholMode.Size = new System.Drawing.Size(100, 21);
            this.cboAlcoholMode.TabIndex = 5;
            this.cboAlcoholMode.SelectedIndexChanged += new System.EventHandler(this.cboAlcoholMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "mL";
            // 
            // nudVolume
            // 
            this.nudVolume.Location = new System.Drawing.Point(89, 45);
            this.nudVolume.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.nudVolume.Name = "nudVolume";
            this.nudVolume.Size = new System.Drawing.Size(181, 20);
            this.nudVolume.TabIndex = 3;
            this.nudVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudVolume.ValueChanged += new System.EventHandler(this.nudVolume_ValueChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(41, 47);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 2;
            this.lblVolume.Text = "&Volume";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(48, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name";
            // 
            // groupSKU
            // 
            this.groupSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSKU.Controls.Add(this.dgvSKUs);
            this.groupSKU.Location = new System.Drawing.Point(12, 128);
            this.groupSKU.Name = "groupSKU";
            this.groupSKU.Size = new System.Drawing.Size(317, 229);
            this.groupSKU.TabIndex = 1;
            this.groupSKU.TabStop = false;
            this.groupSKU.Text = "SKUs";
            // 
            // dgvSKUs
            // 
            this.dgvSKUs.AutoGenerateColumns = false;
            this.dgvSKUs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSKUs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.Quantity,
            this.Enabled});
            this.dgvSKUs.DataSource = this.skuBindingSource;
            this.dgvSKUs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSKUs.Location = new System.Drawing.Point(3, 16);
            this.dgvSKUs.Name = "dgvSKUs";
            this.dgvSKUs.Size = new System.Drawing.Size(311, 210);
            this.dgvSKUs.TabIndex = 0;
            this.dgvSKUs.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvSKUs_DefaultValuesNeeded);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(254, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(173, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // skuBindingSource
            // 
            this.skuBindingSource.DataSource = typeof(Lloyd.Database.Entities.Sku);
            this.skuBindingSource.Filter = "";
            this.skuBindingSource.Sort = "Id";
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.FillWeight = 150F;
            this.Barcode.Frozen = true;
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ToolTipText = "The barcode of the pack.";
            this.Barcode.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.FillWeight = 60F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ToolTipText = "The quantity of the beverage that is contained this barcoded pack.";
            this.Quantity.Width = 60;
            // 
            // Enabled
            // 
            this.Enabled.DataPropertyName = "IsEnabled";
            this.Enabled.FillWeight = 50F;
            this.Enabled.HeaderText = "Enabled";
            this.Enabled.Name = "Enabled";
            this.Enabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Enabled.ToolTipText = "Is this item scannable in the interface?";
            this.Enabled.Width = 50;
            // 
            // frmDrinkEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 395);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupSKU);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDrinkEditor";
            this.Text = "Drink Editor: {0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDrinkEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmDrinkEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlcohol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
            this.groupSKU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSKUs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAlcohol;
        private System.Windows.Forms.ComboBox cboAlcoholMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudVolume;
        private System.Windows.Forms.NumericUpDown nudAlcohol;
        private System.Windows.Forms.GroupBox groupSKU;
        private System.Windows.Forms.DataGridView dgvSKUs;
        private System.Windows.Forms.BindingSource skuBindingSource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
    }
}