
namespace ProducersBank
{
    partial class RecentBatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stickersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentStampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDRList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecentBatch = new System.Windows.Forms.TextBox();
            this.txtDrNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDRList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.printDRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.searchToolStripMenuItem.Text = "Generate";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // printDRToolStripMenuItem
            // 
            this.printDRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveryReceiptToolStripMenuItem,
            this.stickersToolStripMenuItem,
            this.packingToolStripMenuItem,
            this.salesInvoiceToolStripMenuItem,
            this.documentStampToolStripMenuItem});
            this.printDRToolStripMenuItem.Enabled = false;
            this.printDRToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDRToolStripMenuItem.Name = "printDRToolStripMenuItem";
            this.printDRToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.printDRToolStripMenuItem.Text = "Print Reports";
            this.printDRToolStripMenuItem.Click += new System.EventHandler(this.printDRToolStripMenuItem_Click);
            // 
            // deliveryReceiptToolStripMenuItem
            // 
            this.deliveryReceiptToolStripMenuItem.Name = "deliveryReceiptToolStripMenuItem";
            this.deliveryReceiptToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.deliveryReceiptToolStripMenuItem.Text = "Delivery Receipt";
            this.deliveryReceiptToolStripMenuItem.Click += new System.EventHandler(this.deliveryReceiptToolStripMenuItem_Click);
            // 
            // stickersToolStripMenuItem
            // 
            this.stickersToolStripMenuItem.Name = "stickersToolStripMenuItem";
            this.stickersToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.stickersToolStripMenuItem.Text = "Stickers";
            this.stickersToolStripMenuItem.Click += new System.EventHandler(this.stickersToolStripMenuItem_Click);
            // 
            // packingToolStripMenuItem
            // 
            this.packingToolStripMenuItem.Name = "packingToolStripMenuItem";
            this.packingToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.packingToolStripMenuItem.Text = "Packing";
            this.packingToolStripMenuItem.Click += new System.EventHandler(this.packingToolStripMenuItem_Click);
            // 
            // salesInvoiceToolStripMenuItem
            // 
            this.salesInvoiceToolStripMenuItem.Name = "salesInvoiceToolStripMenuItem";
            this.salesInvoiceToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.salesInvoiceToolStripMenuItem.Text = "Sales Invoice";
            this.salesInvoiceToolStripMenuItem.Click += new System.EventHandler(this.salesInvoiceToolStripMenuItem_Click);
            // 
            // documentStampToolStripMenuItem
            // 
            this.documentStampToolStripMenuItem.Name = "documentStampToolStripMenuItem";
            this.documentStampToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.documentStampToolStripMenuItem.Text = "Document Stamp";
            this.documentStampToolStripMenuItem.Click += new System.EventHandler(this.documentStampToolStripMenuItem_Click);
            // 
            // dgvDRList
            // 
            this.dgvDRList.AllowUserToAddRows = false;
            this.dgvDRList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDRList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDRList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDRList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDRList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDRList.Location = new System.Drawing.Point(13, 73);
            this.dgvDRList.Name = "dgvDRList";
            this.dgvDRList.ReadOnly = true;
            this.dgvDRList.Size = new System.Drawing.Size(860, 160);
            this.dgvDRList.TabIndex = 1;
            this.dgvDRList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDRList_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Batch/SalesInvoiceNo :";
            // 
            // txtRecentBatch
            // 
            this.txtRecentBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecentBatch.Location = new System.Drawing.Point(196, 36);
            this.txtRecentBatch.Name = "txtRecentBatch";
            this.txtRecentBatch.Size = new System.Drawing.Size(122, 22);
            this.txtRecentBatch.TabIndex = 1;
            this.txtRecentBatch.TextChanged += new System.EventHandler(this.txtRecentBatch_TextChanged);
            // 
            // txtDrNumber
            // 
            this.txtDrNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDrNumber.Location = new System.Drawing.Point(178, 258);
            this.txtDrNumber.Name = "txtDrNumber";
            this.txtDrNumber.Size = new System.Drawing.Size(140, 22);
            this.txtDrNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Existing DR Number :";
            // 
            // btnChange
            // 
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(319, 51);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(82, 27);
            this.btnChange.TabIndex = 5;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnChange);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 93);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maintenace";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(165, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "New DR Number :";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(593, 36);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 24);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(324, 39);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(159, 16);
            this.lblNote.TabIndex = 8;
            this.lblNote.Text = "This is Batch Number!";
            // 
            // RecentBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 344);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDrNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRecentBatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDRList);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RecentBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recent Batch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecentBatch_FormClosing);
            this.Load += new System.EventHandler(this.RecentBatch_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDRList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvDRList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecentBatch;
        private System.Windows.Forms.ToolStripMenuItem printDRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveryReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stickersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesInvoiceToolStripMenuItem;
        private System.Windows.Forms.TextBox txtDrNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem documentStampToolStripMenuItem;
        private System.Windows.Forms.Label lblNote;
    }
}