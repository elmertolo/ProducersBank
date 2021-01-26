﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProducersBank.Services;
using static ProducersBank.GlobalVariables;
using ProducersBank.Models;
using ProducersBank.Procedures;
using CrystalDecisions.CrystalReports.Engine;

namespace ProducersBank
{
    public partial class frmPurchaseOrder : Form
    {
        List<PurchaseOrderModel> purchaseOrderList = new List<PurchaseOrderModel>();
        ProcessServices_Nelson proc = new ProcessServices_Nelson();
        Main frm;

        public frmPurchaseOrder(Main frm1)
        {
            InitializeComponent();
            ConfigureGrids();
            FillComboBoxes();
            ConfigureDesignLabels();
            purchaseOrderList.Clear();
            this.frm = frm1;

        }

        private void frmPurcahseOrder_Load(object sender, EventArgs e)
        {
            RefreshView();
            DisableControls();
        }

        private void ConfigureGrids()
        {
            //GRID 1
            //dgvItemList.AutoGenerateColumns = false;
            dgvItemList.AllowUserToAddRows = false;
            dgvItemList.AllowUserToResizeColumns = false;
            dgvItemList.AllowUserToDeleteRows = false;
            dgvItemList.AllowUserToOrderColumns = false;
            dgvItemList.AllowUserToResizeRows = false;
            dgvItemList.AllowUserToAddRows = false;
            dgvItemList.ScrollBars = ScrollBars.Vertical;
            dgvItemList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Rename datagrid columns programmatically
            dgvItemList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvItemList.ColumnCount = 5; //COUNT OF COLUMNS THAT WILL DISPLAY IN GRID

            //Column names and width setup
            dgvItemList.Columns[0].Name = "PRODUCT CODE";
            dgvItemList.Columns[0].Width = 150;
            dgvItemList.Columns[0].DataPropertyName = "ProductCode";

            dgvItemList.Columns[1].Name = "CHECK NAME";
            dgvItemList.Columns[1].Width = 300;
            dgvItemList.Columns[1].DataPropertyName = "ChequeName"; //this must be the actual table name in sql

            dgvItemList.Columns[2].Name = "UNIT PRICE";
            dgvItemList.Columns[2].Width = 100;
            dgvItemList.Columns[2].DataPropertyName = "unitprice";

            dgvItemList.Columns[3].Name = "DOCSTAMP";
            dgvItemList.Columns[3].Width = 1000;
            dgvItemList.Columns[3].DataPropertyName = "docstamp";

            dgvItemList.Columns[4].Name = "DESCRIPTION";
            dgvItemList.Columns[4].Width = 50;
            dgvItemList.Columns[4].DataPropertyName = "Description";

    

            //GRID 2
            //dgvItemList.AutoGenerateColumns = true;
            dgvListToProcess.AllowUserToAddRows = false;
            dgvListToProcess.AllowUserToResizeColumns = false;
            //dgvListToProcess.AllowUserToDeleteRows = false;
            dgvListToProcess.AllowUserToOrderColumns = false;
            dgvListToProcess.AllowUserToResizeRows = false;
            dgvListToProcess.AllowUserToAddRows = false;
            dgvListToProcess.ScrollBars = ScrollBars.Vertical;
            //dgvListToProcess.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Rename datagrid columns programmatically
            dgvListToProcess.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvListToProcess.ColumnCount = 6; //COUNT OF COLUMNS THAT WILL DISPLAY IN GRID

            //Column names and width setup

            dgvListToProcess.Columns[0].Name = "QUANTITY";
            dgvListToProcess.Columns[0].Width = 100;
            //dgvListToProcess.Columns[0].DataPropertyName = "Quantity";

            dgvListToProcess.Columns[1].Name = "PRODUCT CODE";
            dgvListToProcess.Columns[1].Width = 120;
            dgvListToProcess.Columns[1].DataPropertyName = "ProductCode"; //this must be the actual table name in sql

            dgvListToProcess.Columns[2].Name = "CHECK NAME";
            dgvListToProcess.Columns[2].Width = 400;
            dgvListToProcess.Columns[2].DataPropertyName = "ChequeName";

            dgvListToProcess.Columns[3].Name = "UNIT PRICE";
            dgvListToProcess.Columns[3].Width = 100;
            dgvListToProcess.Columns[3].DataPropertyName = "UnitPrice";

            dgvListToProcess.Columns[4].Name = "DOCSTAMP";
            dgvListToProcess.Columns[4].Width = 1000;
            dgvListToProcess.Columns[4].DataPropertyName = "Docstamp";

            dgvListToProcess.Columns[5].Name = "DESCRIPTION";
            dgvListToProcess.Columns[5].Width = 1000;
            dgvListToProcess.Columns[5].DataPropertyName = "Description";


        }

        private void FillComboBoxes()
        {
            DataTable dt = new DataTable();
            if (!proc.GetUserNames(ref dt))
            {
                MessageBox.Show("Unable to connect to server. \r\n" + proc.errorMessage);
            }

            _ = dt.Rows.Count != 0 ? cbCheckedBy.DataSource = dt : cbCheckedBy.DataSource = null;
            cbCheckedBy.BindingContext = new BindingContext();
            cbCheckedBy.DisplayMember = "UserName";
            cbCheckedBy.SelectedIndex = -1;

            _ = dt.Rows.Count != 0 ? cbApprovedBy.DataSource = dt : cbApprovedBy.DataSource = null;
            cbApprovedBy.BindingContext = new BindingContext();
            cbApprovedBy.DisplayMember = "UserName";
            cbApprovedBy.SelectedIndex = -1;

        }

        public void ConfigureDesignLabels()
        {
            string fullname = gUser.UserName + " " + gUser.LastName;

            lblUserName.Text = fullname;
            lblBankName.Text = gClient.Description;

        }

        private void AddSelectedItemRow()
        {

            if (dgvItemList.SelectedRows != null && dgvItemList.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvItemList.SelectedRows)
                {
                    //insert record to Items to process in datagrid
                    dgvListToProcess.Rows.Add
                    (
                    0, 
                    row.Cells["Product Code"].Value.ToString(), 
                    row.Cells["Check Name"].Value.ToString(),
                    string.Format("{0,12:#.00}", row.Cells["Unit Price"].Value), 
                    string.Format("{0,12:#.00}", row.Cells["DocStamp"].Value),
                    row.Cells["Description"].Value.ToString()
                    );


                }
                //Disable editing on other columns
                foreach (DataGridViewColumn col in dgvListToProcess.Columns)
                {
                    if (col.Name != "QUANTITY")
                    {
                        dgvListToProcess.Columns[col.Name.ToString()].ReadOnly = true;
                    }

                }
                // Put datagriview ready to edit
                
                dgvListToProcess.CurrentCell = dgvListToProcess[0, dgvListToProcess.Rows.Count - 1];
                dgvListToProcess.BeginEdit(true);

                ///REPLACED THIS WITH MANUAL ISERTION OF DATA ABOVE
                //created 'list' variable column sorting by line for datagrid view 
                //var sortedList = purchaseOrderList
                //    .Select
                //    (i => new { i.Quantity, i.ProductCode, i.ChequeName, i.UnitPrice, i.Docstamp })

                //    .ToList();

                //dgvListToProcess.DataSource = sortedList;
                //dgvListToProcess.ClearSelection();



            }
            else
            {
                MessageBox.Show("Please select at least one record");
            }


        }

        private void btnAddSelectedItem_Click(object sender, EventArgs e)
        {
            AddSelectedItemRow();
        }

        private void btnSavePrintPO_Click(object sender, EventArgs e)
        {

            if (!p.ValidateInputFieldsPO(txtPONumber.Text.ToString(), cbCheckedBy.Text.ToString(), cbApprovedBy.Text.ToString()))
            {
                MessageBox.Show("Please supply values in blank field(s)");
            }
            else if (dgvListToProcess.Rows.Count == 0)
            {
                MessageBox.Show("Please select record from Item List.");
            }
            else
            {

                DialogResult result = MessageBox.Show("This will update Purchase Order on selected Items. \r\n Select 'YES' to proceed.", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {


                    foreach (DataGridViewRow row in dgvListToProcess.Rows)
                    {
                        PurchaseOrderModel line = new PurchaseOrderModel();

                        //Validation for zero quantity
                        if (int.Parse(row.Cells["Quantity"].Value.ToString()) <= 0)
                        {
                            MessageBox.Show("Zero quantity is not accepted.");
                            return;
                        }

                        line.PurchaseOrderNumber = int.Parse(txtPONumber.Text.ToString());
                        line.PurchaseOrderDateTime = DateTime.Parse(dtpPODate.Value.ToString());
                        line.ClientCode = gClient.ClientCode;
                        line.ProductCode = row.Cells["Product Code"].Value.ToString();
                        line.Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        line.ChequeName = row.Cells["Check Name"].Value.ToString();
                        line.Description = row.Cells["Description"].Value.ToString();
                        line.UnitPrice = double.Parse(row.Cells["Unit Price"].Value.ToString());
                        line.Docstamp = double.Parse(row.Cells["DocStamp"].Value.ToString());
                        line.GeneratedBy = lblUserName.Text.ToString();
                        line.CheckedBy = cbCheckedBy.Text.ToString();
                        line.ApprovedBy = cbApprovedBy.Text.ToString();
                        
                        purchaseOrderList.Add(line);

                    }

                    ///Sort Sales Invoice By Batch before saving and Printing
                    var sortedList = purchaseOrderList.OrderBy(x => x.ChequeName).ToList();


                    ///Update Database
                    if (!proc.UpdatePurchaseOrderFinished(sortedList))
                    {
                        MessageBox.Show("Error updating purchase order record to server. (proc.UpdatePurchaseOrderFinished) \r\n" + proc.errorMessage);
                        return;
                    }


                    ///DONT REMOVE THIS COMMENT BLOCK.. THIS CODE SERVES AS A REPORT PRINTING WHEN CLIENT NEEDED IT JUST IN CASE.
                    
                    ////Create new instance of the document/ Prepare report using Crystal Reports
                    //ReportDocument crystalDocument = new ReportDocument();


                    ////Check RPT File
                    //if (!p.LoadReportPath("PurchaseOrder", ref crystalDocument))
                    //{
                    //    MessageBox.Show("purchase Order Report File not found File not found");
                    //    return;
                    //}

                    ////Supply Data source to document
                    //crystalDocument.SetDataSource(sortedList);

                    ////Supply details on report parameters
                    //p.FillCRReportParameters("SalesInvoice", ref crystalDocument);


                    ////Supply these details into Global ReportDocument to be able for the report viewer to initialize the rerport
                    //gCrystalDocument = crystalDocument;

                    //frmReportViewer crForm = new frmReportViewer();
                    //crForm.Show();

                    RefreshView();
                    DisableControls();
                    MessageBox.Show("Record has been saved successfully.");

                }

            }
        }

        private void btnReloadDrList_Click(object sender, EventArgs e)
        {
            RefreshView();
            DisableControls();
        }

        private void RefreshView()
        {

            purchaseOrderList.Clear();
            txtSearch.Clear();
            txtPONumber.Clear();
            txtPONumber.Focus();
            cbCheckedBy.Text = "";
            cbApprovedBy.Text = "";

            dgvListToProcess.Rows.Clear();
            dgvListToProcess.ClearSelection();

            DisableControls();

        }

        private void dgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddSelectedItemRow();
        }

        private void txtPONumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (p.IsKeyPressedNumeric(ref sender, ref e))
            {
                e.Handled = true;
            }
        }

        private void txtPONumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPONumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtPONumber.Text.ToString()))
                {
                    MessageBox.Show("Please enter a valid PO number");
                    return;
                }
                EnableControls();

            }
        }

        private void EnableControls()
        {
            gbSearchItem.Enabled = true;
            gbItemList.Enabled = true;
            gbDetails.Enabled = true;
            gbListToProcess.Enabled = true;
            pnlActionButtons.Enabled = true;
            gbPONo.Enabled = false;

            DataTable dt = new DataTable();
            if (!proc.LoadPriceListData(ref dt))
            {
                MessageBox.Show("Server Connection Error (LoadPriceListData) \r\n" + proc.errorMessage);
                RefreshView();
                return;
            }

            dgvItemList.DataSource = dt;
            dgvItemList.ClearSelection(); // remove first highlighted row in datagrid
            btnAddRecord.Focus();
        }

        private void DisableControls()
        {
            gbSearchItem.Enabled = false;
            gbItemList.Enabled = false;
            gbDetails.Enabled = false;
            gbListToProcess.Enabled = false;
            pnlActionButtons.Enabled = false;
            gbPONo.Enabled = true;
            
            dgvItemList.ClearSelection();
            //remove first highlighted row in datagrid
            var sortedList = purchaseOrderList
               .Select
               (i => new { i.Quantity, i.ProductCode, i.ChequeName, i.UnitPrice, i.Docstamp })
               .ToList();
            dgvItemList.DataSource = sortedList;
            txtPONumber.Focus();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPONumber.Text.ToString()))
            {
                MessageBox.Show("Please enter a valid PO number");
                txtPONumber.Focus();
                return;
            }
            EnableControls();
        }

        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
