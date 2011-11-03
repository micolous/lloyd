﻿namespace Lloyd
{
    partial class frmEditor
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
            this.lvBeverages = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addDrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableDisableDrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvBeverages
            // 
            this.lvBeverages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvBeverages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBeverages.Location = new System.Drawing.Point(0, 24);
            this.lvBeverages.Name = "lvBeverages";
            this.lvBeverages.Size = new System.Drawing.Size(542, 293);
            this.lvBeverages.TabIndex = 0;
            this.lvBeverages.UseCompatibleStateImageBehavior = false;
            this.lvBeverages.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDrinkToolStripMenuItem,
            this.editDrinkToolStripMenuItem,
            this.enableDisableDrinkToolStripMenuItem,
            this.deleteDrinkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addDrinkToolStripMenuItem
            // 
            this.addDrinkToolStripMenuItem.Name = "addDrinkToolStripMenuItem";
            this.addDrinkToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.addDrinkToolStripMenuItem.Text = "Add Drink";
            // 
            // editDrinkToolStripMenuItem
            // 
            this.editDrinkToolStripMenuItem.Name = "editDrinkToolStripMenuItem";
            this.editDrinkToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.editDrinkToolStripMenuItem.Text = "Edit Drink";
            // 
            // enableDisableDrinkToolStripMenuItem
            // 
            this.enableDisableDrinkToolStripMenuItem.Name = "enableDisableDrinkToolStripMenuItem";
            this.enableDisableDrinkToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.enableDisableDrinkToolStripMenuItem.Text = "Enable/Disable Drink";
            // 
            // deleteDrinkToolStripMenuItem
            // 
            this.deleteDrinkToolStripMenuItem.Name = "deleteDrinkToolStripMenuItem";
            this.deleteDrinkToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.deleteDrinkToolStripMenuItem.Text = "Delete Drink";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 195;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Volume";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alc. Vol.";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Std Drinks";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 64;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SKUs";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 44;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stock";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 43;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Enabled";
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 317);
            this.Controls.Add(this.lvBeverages);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEditor";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBeverages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addDrinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDrinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDisableDrinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDrinkToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;

    }
}