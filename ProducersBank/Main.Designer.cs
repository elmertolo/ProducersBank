﻿namespace ProducersBank
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentStampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionsToolStripMenuItem,
            this.recentBatchToolStripMenuItem,
            this.maintenanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1304, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveryReceiptToolStripMenuItem,
            this.salesInvoiceToolStripMenuItem,
            this.documentStampToolStripMenuItem});
            this.transactionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.ShortcutKeyDisplayString = "T";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // deliveryReceiptToolStripMenuItem
            // 
            this.deliveryReceiptToolStripMenuItem.Name = "deliveryReceiptToolStripMenuItem";
            this.deliveryReceiptToolStripMenuItem.ShortcutKeyDisplayString = "D";
            this.deliveryReceiptToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.deliveryReceiptToolStripMenuItem.Text = "Delivery Receipt";
            this.deliveryReceiptToolStripMenuItem.Click += new System.EventHandler(this.deliveryReceiptToolStripMenuItem_Click);
            // 
            // salesInvoiceToolStripMenuItem
            // 
            this.salesInvoiceToolStripMenuItem.Name = "salesInvoiceToolStripMenuItem";
            this.salesInvoiceToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.salesInvoiceToolStripMenuItem.Text = "Sales Invoice";
            this.salesInvoiceToolStripMenuItem.Click += new System.EventHandler(this.salesInvoiceToolStripMenuItem_Click);
            // 
            // documentStampToolStripMenuItem
            // 
            this.documentStampToolStripMenuItem.Name = "documentStampToolStripMenuItem";
            this.documentStampToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.documentStampToolStripMenuItem.Text = "Document Stamp";
            this.documentStampToolStripMenuItem.Click += new System.EventHandler(this.documentStampToolStripMenuItem_Click);
            // 
            // recentBatchToolStripMenuItem
            // 
            this.recentBatchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentBatchToolStripMenuItem.Name = "recentBatchToolStripMenuItem";
            this.recentBatchToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.recentBatchToolStripMenuItem.Text = "Recent Batch";
            this.recentBatchToolStripMenuItem.Click += new System.EventHandler(this.recentBatchToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderToolStripMenuItem,
            this.changeDRToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // purchaseOrderToolStripMenuItem
            // 
            this.purchaseOrderToolStripMenuItem.Name = "purchaseOrderToolStripMenuItem";
            this.purchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.purchaseOrderToolStripMenuItem.Text = "Purchase Order";
            this.purchaseOrderToolStripMenuItem.Click += new System.EventHandler(this.purchaseOrderToolStripMenuItem_Click_1);
            // 
            // changeDRToolStripMenuItem
            // 
            this.changeDRToolStripMenuItem.Name = "changeDRToolStripMenuItem";
            this.changeDRToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.changeDRToolStripMenuItem.Text = "Change DR";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1304, 742);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Producers Bank";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveryReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentStampToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDRToolStripMenuItem;

        //private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem purchaseOrderToolStripMenuItem;

    }
}

