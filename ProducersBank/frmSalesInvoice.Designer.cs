
namespace ProducersBank
{
    partial class frmSalesInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesInvoice));
            this.dgvDRList = new System.Windows.Forms.DataGridView();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblDRList = new System.Windows.Forms.Label();
            this.txtSalesInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearchBatchNo = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dgvListToProcess = new System.Windows.Forms.DataGridView();
            this.btnViewSelected = new System.Windows.Forms.Button();
            this.btnPrintSalesInvoice = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPreparedBy = new System.Windows.Forms.ComboBox();
            this.cbCheckedBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbApprovedBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDRList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListToProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDRList
            // 
            this.dgvDRList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDRList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDRList.Location = new System.Drawing.Point(266, 44);
            this.dgvDRList.Name = "dgvDRList";
            this.dgvDRList.Size = new System.Drawing.Size(730, 329);
            this.dgvDRList.TabIndex = 0;
            this.dgvDRList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDRList_CellContentClick);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Location = new System.Drawing.Point(16, 66);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(223, 26);
            this.dtpInvoiceDate.TabIndex = 2;
            // 
            // lblDRList
            // 
            this.lblDRList.AutoSize = true;
            this.lblDRList.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDRList.Location = new System.Drawing.Point(12, 44);
            this.lblDRList.Name = "lblDRList";
            this.lblDRList.Size = new System.Drawing.Size(98, 19);
            this.lblDRList.TabIndex = 1;
            this.lblDRList.Text = "Invoice Date:";
            // 
            // txtSalesInvoiceNumber
            // 
            this.txtSalesInvoiceNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesInvoiceNumber.Location = new System.Drawing.Point(16, 130);
            this.txtSalesInvoiceNumber.Name = "txtSalesInvoiceNumber";
            this.txtSalesInvoiceNumber.Size = new System.Drawing.Size(223, 27);
            this.txtSalesInvoiceNumber.TabIndex = 3;
            this.txtSalesInvoiceNumber.TextChanged += new System.EventHandler(this.txtSalesInvoiceNumber_TextChanged);
            this.txtSalesInvoiceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesInvoiceNumber_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sales Invoice Number:";
            // 
            // lblSearchBatchNo
            // 
            this.lblSearchBatchNo.AutoSize = true;
            this.lblSearchBatchNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBatchNo.Location = new System.Drawing.Point(262, 9);
            this.lblSearchBatchNo.Name = "lblSearchBatchNo";
            this.lblSearchBatchNo.Size = new System.Drawing.Size(102, 19);
            this.lblSearchBatchNo.TabIndex = 7;
            this.lblSearchBatchNo.Text = "Search Batch:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(370, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 27);
            this.textBox2.TabIndex = 6;
            // 
            // dgvListToProcess
            // 
            this.dgvListToProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListToProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListToProcess.Location = new System.Drawing.Point(8, 448);
            this.dgvListToProcess.Name = "dgvListToProcess";
            this.dgvListToProcess.Size = new System.Drawing.Size(988, 201);
            this.dgvListToProcess.TabIndex = 8;
            // 
            // btnViewSelected
            // 
            this.btnViewSelected.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnViewSelected.Location = new System.Drawing.Point(813, 385);
            this.btnViewSelected.Name = "btnViewSelected";
            this.btnViewSelected.Size = new System.Drawing.Size(183, 50);
            this.btnViewSelected.TabIndex = 9;
            this.btnViewSelected.Text = "VIEW SELECTED BATCH";
            this.btnViewSelected.UseVisualStyleBackColor = true;
            this.btnViewSelected.Click += new System.EventHandler(this.btnViewSelected_Click);
            // 
            // btnPrintSalesInvoice
            // 
            this.btnPrintSalesInvoice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrintSalesInvoice.Location = new System.Drawing.Point(813, 667);
            this.btnPrintSalesInvoice.Name = "btnPrintSalesInvoice";
            this.btnPrintSalesInvoice.Size = new System.Drawing.Size(183, 50);
            this.btnPrintSalesInvoice.TabIndex = 10;
            this.btnPrintSalesInvoice.Text = "GENERATE / PRINT SALES INVOICE";
            this.btnPrintSalesInvoice.UseVisualStyleBackColor = true;
            this.btnPrintSalesInvoice.Click += new System.EventHandler(this.btnPrintSalesInvoice_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Prepared By:";
            // 
            // cbPreparedBy
            // 
            this.cbPreparedBy.FormattingEnabled = true;
            this.cbPreparedBy.Location = new System.Drawing.Point(16, 193);
            this.cbPreparedBy.Name = "cbPreparedBy";
            this.cbPreparedBy.Size = new System.Drawing.Size(223, 21);
            this.cbPreparedBy.TabIndex = 12;
            // 
            // cbCheckedBy
            // 
            this.cbCheckedBy.FormattingEnabled = true;
            this.cbCheckedBy.Location = new System.Drawing.Point(17, 244);
            this.cbCheckedBy.Name = "cbCheckedBy";
            this.cbCheckedBy.Size = new System.Drawing.Size(223, 21);
            this.cbCheckedBy.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Checked By:";
            // 
            // cbApprovedBy
            // 
            this.cbApprovedBy.FormattingEnabled = true;
            this.cbApprovedBy.Location = new System.Drawing.Point(17, 294);
            this.cbApprovedBy.Name = "cbApprovedBy";
            this.cbApprovedBy.Size = new System.Drawing.Size(223, 21);
            this.cbApprovedBy.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Approved By:";
            // 
            // frmSalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.cbApprovedBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCheckedBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPreparedBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrintSalesInvoice);
            this.Controls.Add(this.btnViewSelected);
            this.Controls.Add(this.dgvListToProcess);
            this.Controls.Add(this.lblSearchBatchNo);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalesInvoiceNumber);
            this.Controls.Add(this.dtpInvoiceDate);
            this.Controls.Add(this.lblDRList);
            this.Controls.Add(this.dgvDRList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesInvoice_FormClosing);
            this.Load += new System.EventHandler(this.frmSalesInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDRList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListToProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDRList;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label lblDRList;
        private System.Windows.Forms.TextBox txtSalesInvoiceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSearchBatchNo;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dgvListToProcess;
        private System.Windows.Forms.Button btnViewSelected;
        private System.Windows.Forms.Button btnPrintSalesInvoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPreparedBy;
        private System.Windows.Forms.ComboBox cbCheckedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbApprovedBy;
        private System.Windows.Forms.Label label4;
    }
}