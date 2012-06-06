namespace Lloyd
{
    partial class frmDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnEditor = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScannedDrink = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 21);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(548, 47);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Hello, {0}.";
            // 
            // btnUserManager
            // 
            this.btnUserManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserManager.Location = new System.Drawing.Point(566, 76);
            this.btnUserManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(125, 55);
            this.btnUserManager.TabIndex = 3;
            this.btnUserManager.Text = "&Users";
            this.btnUserManager.UseVisualStyleBackColor = true;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.Location = new System.Drawing.Point(566, 13);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(125, 55);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "&Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnEditor
            // 
            this.btnEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditor.Location = new System.Drawing.Point(566, 139);
            this.btnEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditor.Name = "btnEditor";
            this.btnEditor.Size = new System.Drawing.Size(125, 55);
            this.btnEditor.TabIndex = 4;
            this.btnEditor.Text = "&Editor";
            this.btnEditor.UseVisualStyleBackColor = true;
            this.btnEditor.Click += new System.EventHandler(this.btnEditor_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.AcceptsReturn = true;
            this.txtBarcode.Location = new System.Drawing.Point(19, 151);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(477, 33);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(435, 13);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(125, 55);
            this.btnCheckIn.TabIndex = 1;
            this.btnCheckIn.Text = "Check in";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Scan a barcode to check out the drink.";
            // 
            // lblScannedDrink
            // 
            this.lblScannedDrink.AutoSize = true;
            this.lblScannedDrink.Location = new System.Drawing.Point(25, 250);
            this.lblScannedDrink.Name = "lblScannedDrink";
            this.lblScannedDrink.Size = new System.Drawing.Size(63, 25);
            this.lblScannedDrink.TabIndex = 7;
            this.lblScannedDrink.Text = "label2";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnLogout;
            this.ClientSize = new System.Drawing.Size(703, 472);
            this.ControlBox = false;
            this.Controls.Add(this.lblScannedDrink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.btnEditor);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.lblWelcome);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lloyd - Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnEditor;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScannedDrink;
    }
}