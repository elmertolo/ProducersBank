using System;
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
            DataTable dt = new DataTable();
            if (!proc.LoadPriceListData(ref dt))
            {
                MessageBox.Show("Server Connection Error (LoadInitialData) \r\n" + proc.errorMessage);
                return;
            }

            dgvItemList.DataSource = dt;
            dgvItemList.ClearSelection(); // remove first highlighted row in datagrid
            txtPONumber.Focus();
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
            dgvItemList.ColumnCount = 4; //COUNT OF COLUMNS THAT WILL DISPLAY IN GRID

            //Column names and width setup
            dgvItemList.Columns[0].Name = "Product Code";
            dgvItemList.Columns[0].Width = 70;
            dgvItemList.Columns[0].DataPropertyName = "ProductCode";

            dgvItemList.Columns[1].Name = "CHECK NAME";
            dgvItemList.Columns[1].Width = 250;
            dgvItemList.Columns[1].DataPropertyName = "ChequeName"; //this must be the actual table name in sql

            dgvItemList.Columns[2].Name = "Unit Price";
            dgvItemList.Columns[2].Width = 70;
            dgvItemList.Columns[2].DataPropertyName = "UnitPrice";

            dgvItemList.Columns[3].Name = "Docstamp";
            dgvItemList.Columns[3].Width = 70;
            dgvItemList.Columns[3].DataPropertyName = "Docstamp";


            //GRID 2
            //dgvItemList.AutoGenerateColumns = true;
            dgvListToProcess.AllowUserToAddRows = false;
            dgvListToProcess.AllowUserToResizeColumns = false;
            dgvListToProcess.AllowUserToDeleteRows = false;
            dgvListToProcess.AllowUserToOrderColumns = false;
            dgvListToProcess.AllowUserToResizeRows = false;
            dgvListToProcess.AllowUserToAddRows = false;
            dgvListToProcess.ScrollBars = ScrollBars.Vertical;
            dgvListToProcess.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Rename datagrid columns programmatically
            dgvListToProcess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvListToProcess.ColumnCount = 8; //COUNT OF COLUMNS THAT WILL DISPLAY IN GRID

            //Column names and width setup

            dgvListToProcess.Columns[0].Name = "QUANTITY";
            dgvListToProcess.Columns[0].Width = 50;
            dgvListToProcess.Columns[0].DataPropertyName = "Quantity";

            dgvListToProcess.Columns[1].Name = "PRODUCT CODE";
            dgvListToProcess.Columns[1].Width = 100;
            dgvListToProcess.Columns[1].DataPropertyName = "ProductCode"; //this must be the actual table name in sql

            dgvListToProcess.Columns[2].Name = "CHECK NAME";
            dgvListToProcess.Columns[2].Width = 400;
            dgvListToProcess.Columns[2].DataPropertyName = "CheckName";

            dgvListToProcess.Columns[3].Name = "UNIT PRICE";
            dgvListToProcess.Columns[3].Width = 70;
            dgvListToProcess.Columns[3].DataPropertyName = "Unit Price";

            dgvListToProcess.Columns[4].Name = "DOCSTAMP";
            dgvListToProcess.Columns[4].Width = 70;
            dgvListToProcess.Columns[4].DataPropertyName = "Docstamp";


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
                    PurchaseOrderModel line = new PurchaseOrderModel();

                    line.PurchaseOrderNumber = int.Parse(row.Cells["PurchaseOrderNo"].Value.ToString());
                    line.PurchaseOrderDateTime = DateTime.Parse(dtpPODate.Value.ToShortDateString());
                    line.ProductCode = row.Cells["ProductCode"].Value.ToString();
                    line.Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    line.ChequeName = row.Cells["CheckName"].Value.ToString();
                    line.Description = row.Cells["Description"].Value.ToString();
                    line.UnitPrice = int.Parse(row.Cells["UnitPrice"].Value.ToString());
                    line.Docstamp = int.Parse(row.Cells["DocStamp"].Value.ToString());
                    line.CheckType = row.Cells["CheckType"].Value.ToString();

                    purchaseOrderList.Add(line);
                }

                //created 'list' variable column sorting by line for datagrid view 
                var sortedList = purchaseOrderList
                    .Select
                    (i => new { i.Quantity, i.ProductCode, i.ChequeName, i.UnitPrice, i.Docstamp })

                    .ToList();

                dgvListToProcess.DataSource = sortedList;
                dgvListToProcess.ClearSelection();

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


                    ///Sort Sales Invoice By Batch before saving and Printing
                    var sortedList = purchaseOrderList.OrderBy(x => x.ChequeName).ToList();


                    ///Update Database
                    if (!proc.UpdatePurchaseOrderFinished(sortedList))
                    {
                        MessageBox.Show("Error updating purchase order record to server. (proc.UpdatePurchaseOrderFinished) \r\n" + proc.errorMessage);
                        return;
                    }


                    //Create new instance of the document/ Prepare report using Crystal Reports
                    ReportDocument crystalDocument = new ReportDocument();


                    //Check RPT File
                    if (!p.LoadReportPath("PurchaseOrder", ref crystalDocument))
                    {
                        MessageBox.Show("purchase Order Report File not found File not found");
                        return;
                    }

                    //Supply Data source to document
                    crystalDocument.SetDataSource(sortedList);

                    //Supply details on report parameters
                    p.FillCRReportParameters("SalesInvoice", ref crystalDocument);


                    //Supply these details into Global ReportDocument to be able for the report viewer to initialize the rerport
                    gCrystalDocument = crystalDocument;

                    frmReportViewer crForm = new frmReportViewer();
                    crForm.Show();

                    RefreshView();

                }

            }
        }

        private void btnReloadDrList_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {

            purchaseOrderList.Clear();
            txtSearch.Text = "";
            txtPONumber.Text = "";
            txtPONumber.Focus();
            cbCheckedBy.Text = "";
            cbApprovedBy.Text = "";

            DataTable dt = new DataTable();
            proc.LoadPriceListData(ref dt);
            dgvItemList.DataSource = dt;
            dgvItemList.ClearSelection();

            var sortedList = purchaseOrderList
                     .Select
                    (i => new { i.Quantity, i.ProductCode, i.ChequeName, i.UnitPrice, i.Docstamp })
                    .ToList();

            dgvListToProcess.DataSource = sortedList;
            dgvListToProcess.ClearSelection();


        }
    }
}
