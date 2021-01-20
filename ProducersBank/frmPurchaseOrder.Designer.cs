
namespace ProducersBank
{
    partial class frmPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSavePrintPO = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddSelectedItem = new System.Windows.Forms.Button();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.lblDRList = new System.Windows.Forms.Label();
            this.dtpPODate = new System.Windows.Forms.DateTimePicker();
            this.cbApprovedBy = new System.Windows.Forms.ComboBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCheckedBy = new System.Windows.Forms.ComboBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListToProcess = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.btnReloadDrList = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListToProcess)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSavePrintPO
            // 
            this.btnSavePrintPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePrintPO.Location = new System.Drawing.Point(826, 627);
            this.btnSavePrintPO.Name = "btnSavePrintPO";
            this.btnSavePrintPO.Size = new System.Drawing.Size(170, 52);
            this.btnSavePrintPO.TabIndex = 22;
            this.btnSavePrintPO.Text = "SAVE / PRINT PURCHASE ORDER";
            this.btnSavePrintPO.UseVisualStyleBackColor = true;
            this.btnSavePrintPO.Click += new System.EventHandler(this.btnSavePrintPO_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(578, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "label7";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(331, 9);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(83, 13);
            this.lblBankName.TabIndex = 3;
            this.lblBankName.Text = "Producers Bank";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(81, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(40, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Nelson";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(290, 9);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(35, 13);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Bank:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(12, 9);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(63, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "User Name:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblBankName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.Label5);
            this.panel1.Location = new System.Drawing.Point(12, 685);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 32);
            this.panel1.TabIndex = 23;
            // 
            // btnAddSelectedItem
            // 
            this.btnAddSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSelectedItem.Location = new System.Drawing.Point(826, 17);
            this.btnAddSelectedItem.Name = "btnAddSelectedItem";
            this.btnAddSelectedItem.Size = new System.Drawing.Size(170, 52);
            this.btnAddSelectedItem.TabIndex = 24;
            this.btnAddSelectedItem.Text = "ADD SELECTED ITEM";
            this.btnAddSelectedItem.UseVisualStyleBackColor = true;
            this.btnAddSelectedItem.Click += new System.EventHandler(this.btnAddSelectedItem_Click);
            // 
            // gbDetails
            // 
            this.gbDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbDetails.Controls.Add(this.lblDRList);
            this.gbDetails.Controls.Add(this.dtpPODate);
            this.gbDetails.Controls.Add(this.cbApprovedBy);
            this.gbDetails.Controls.Add(this.txtPONumber);
            this.gbDetails.Controls.Add(this.label1);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.label3);
            this.gbDetails.Controls.Add(this.cbCheckedBy);
            this.gbDetails.Location = new System.Drawing.Point(12, 86);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(248, 386);
            this.gbDetails.TabIndex = 26;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "DETAILS";
            // 
            // lblDRList
            // 
            this.lblDRList.AutoSize = true;
            this.lblDRList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDRList.Location = new System.Drawing.Point(6, 38);
            this.lblDRList.Name = "lblDRList";
            this.lblDRList.Size = new System.Drawing.Size(138, 15);
            this.lblDRList.TabIndex = 1;
            this.lblDRList.Text = "PURCHASE ORDER DATE:";
            // 
            // dtpPODate
            // 
            this.dtpPODate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPODate.Location = new System.Drawing.Point(10, 60);
            this.dtpPODate.Name = "dtpPODate";
            this.dtpPODate.Size = new System.Drawing.Size(226, 23);
            this.dtpPODate.TabIndex = 2;
            // 
            // cbApprovedBy
            // 
            this.cbApprovedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbApprovedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbApprovedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApprovedBy.FormattingEnabled = true;
            this.cbApprovedBy.Location = new System.Drawing.Point(90, 339);
            this.cbApprovedBy.Name = "cbApprovedBy";
            this.cbApprovedBy.Size = new System.Drawing.Size(146, 23);
            this.cbApprovedBy.TabIndex = 16;
            // 
            // txtPONumber
            // 
            this.txtPONumber.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPONumber.Location = new System.Drawing.Point(65, 104);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(171, 23);
            this.txtPONumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "PO No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Approved By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Checked By:";
            // 
            // cbCheckedBy
            // 
            this.cbCheckedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCheckedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCheckedBy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCheckedBy.FormattingEnabled = true;
            this.cbCheckedBy.Location = new System.Drawing.Point(90, 310);
            this.cbCheckedBy.Name = "cbCheckedBy";
            this.cbCheckedBy.Size = new System.Drawing.Size(146, 23);
            this.cbCheckedBy.TabIndex = 14;
            // 
            // gbSearch
            // 
            this.gbSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(248, 68);
            this.gbSearch.TabIndex = 25;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "SEARCH PURCHASE ORDER";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(183, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 23);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Go";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(171, 21);
            this.txtSearch.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.dgvListToProcess);
            this.groupBox1.Location = new System.Drawing.Point(12, 478);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 201);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ITEMS TO PROCESS";
            // 
            // dgvListToProcess
            // 
            this.dgvListToProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListToProcess.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListToProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvListToProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListToProcess.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvListToProcess.Location = new System.Drawing.Point(6, 19);
            this.dgvListToProcess.Name = "dgvListToProcess";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListToProcess.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvListToProcess.Size = new System.Drawing.Size(796, 176);
            this.dgvListToProcess.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvItemList);
            this.groupBox2.Location = new System.Drawing.Point(266, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 460);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ITEM LIST";
            // 
            // dgvItemList
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.dgvItemList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvItemList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemList.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvItemList.Location = new System.Drawing.Point(6, 19);
            this.dgvItemList.Name = "dgvItemList";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemList.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvItemList.Size = new System.Drawing.Size(542, 435);
            this.dgvItemList.TabIndex = 0;
            // 
            // btnReloadDrList
            // 
            this.btnReloadDrList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadDrList.Location = new System.Drawing.Point(826, 478);
            this.btnReloadDrList.Name = "btnReloadDrList";
            this.btnReloadDrList.Size = new System.Drawing.Size(170, 52);
            this.btnReloadDrList.TabIndex = 29;
            this.btnReloadDrList.Text = "REFRESH";
            this.btnReloadDrList.UseVisualStyleBackColor = true;
            this.btnReloadDrList.Click += new System.EventHandler(this.btnReloadDrList_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(826, 536);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 52);
            this.button2.TabIndex = 30;
            this.button2.Text = "CANCEL / CLOSE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnReloadDrList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.btnAddSelectedItem);
            this.Controls.Add(this.btnSavePrintPO);
            this.Controls.Add(this.panel1);
            this.Name = "frmPurchaseOrder";
            this.Text = "PURCHASE ORDER";
            this.Load += new System.EventHandler(this.frmPurcahseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListToProcess)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSavePrintPO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSelectedItem;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label lblDRList;
        private System.Windows.Forms.DateTimePicker dtpPODate;
        private System.Windows.Forms.ComboBox cbApprovedBy;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCheckedBy;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListToProcess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.Button btnReloadDrList;
        private System.Windows.Forms.Button button2;
    }
}