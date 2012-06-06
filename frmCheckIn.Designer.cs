namespace Lloyd
{
    partial class frmCheckIn
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLastScanStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRequiresPermission = new System.Windows.Forms.CheckBox();
            this.nudCost = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheckinBarcode = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvStockStatus = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 452);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtCheckinBarcode);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Check In";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLastScanStatus);
            this.groupBox2.Location = new System.Drawing.Point(18, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 193);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Last scan status:";
            // 
            // lblLastScanStatus
            // 
            this.lblLastScanStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastScanStatus.Location = new System.Drawing.Point(3, 29);
            this.lblLastScanStatus.Name = "lblLastScanStatus";
            this.lblLastScanStatus.Size = new System.Drawing.Size(623, 161);
            this.lblLastScanStatus.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(634, 58);
            this.label2.TabIndex = 3;
            this.label2.Text = "To check in a beverage with these parameters, tap below then scan it\'s barcode.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRequiresPermission);
            this.groupBox1.Controls.Add(this.nudCost);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Beverage Parameters";
            // 
            // chkRequiresPermission
            // 
            this.chkRequiresPermission.AutoSize = true;
            this.chkRequiresPermission.Checked = true;
            this.chkRequiresPermission.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRequiresPermission.Location = new System.Drawing.Point(316, 29);
            this.chkRequiresPermission.Name = "chkRequiresPermission";
            this.chkRequiresPermission.Size = new System.Drawing.Size(204, 29);
            this.chkRequiresPermission.TabIndex = 2;
            this.chkRequiresPermission.Text = "Permission Required";
            this.chkRequiresPermission.UseVisualStyleBackColor = true;
            // 
            // nudCost
            // 
            this.nudCost.DecimalPlaces = 2;
            this.nudCost.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudCost.Location = new System.Drawing.Point(86, 31);
            this.nudCost.Name = "nudCost";
            this.nudCost.Size = new System.Drawing.Size(187, 33);
            this.nudCost.TabIndex = 1;
            this.nudCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cost";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCheckinBarcode
            // 
            this.txtCheckinBarcode.AcceptsReturn = true;
            this.txtCheckinBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCheckinBarcode.Location = new System.Drawing.Point(99, 161);
            this.txtCheckinBarcode.MaxLength = 50;
            this.txtCheckinBarcode.Name = "txtCheckinBarcode";
            this.txtCheckinBarcode.Size = new System.Drawing.Size(491, 33);
            this.txtCheckinBarcode.TabIndex = 2;
            this.txtCheckinBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheckinBarcode_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvStockStatus);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(655, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Your Stock Status";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvStockStatus
            // 
            this.dgvStockStatus.AllowUserToAddRows = false;
            this.dgvStockStatus.AllowUserToDeleteRows = false;
            this.dgvStockStatus.AllowUserToResizeRows = false;
            this.dgvStockStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStockStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockStatus.Location = new System.Drawing.Point(0, 0);
            this.dgvStockStatus.Margin = new System.Windows.Forms.Padding(0);
            this.dgvStockStatus.Name = "dgvStockStatus";
            this.dgvStockStatus.ReadOnly = true;
            this.dgvStockStatus.RowHeadersVisible = false;
            this.dgvStockStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvStockStatus.ShowEditingIcon = false;
            this.dgvStockStatus.ShowRowErrors = false;
            this.dgvStockStatus.Size = new System.Drawing.Size(655, 414);
            this.dgvStockStatus.TabIndex = 0;
            // 
            // frmCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 452);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckIn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Stock Check-in";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCost)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvStockStatus;
        private System.Windows.Forms.TextBox txtCheckinBarcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRequiresPermission;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLastScanStatus;
    }
}