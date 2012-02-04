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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudAlcohol = new System.Windows.Forms.NumericUpDown();
            this.lblAlcohol = new System.Windows.Forms.Label();
            this.cboAlcoholMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlcohol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(303, 165);
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
            // frmDrinkEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 369);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDrinkEditor";
            this.Text = "frmDrinkEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlcohol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
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
    }
}