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
using ProducersBank.Models;
using static ProducersBank.GlobalVariables;
using ProducersBank.Procedures;
using FastMember;

namespace ProducersBank
{
    public partial class frmSalesInvoice : Form
    {

        List<SalesInvoiceModel> salesInvoiceList = new List<SalesInvoiceModel>();
        ProcessServices_Nelson proc = new ProcessServices_Nelson();
        Main frm;

        public frmSalesInvoice(Main frm1)
        {

            //Added Validation when unable to connect to server upon Opening salesinvoice form
            if (proc.errorMessage != null)
            {
                MessageBox.Show("Unable connecting to Server (pOpenDB) \r\n" + proc.errorMessage);
                Application.Exit();
            }

            InitializeComponent();
            ConfigureGrids();
            FillComboBoxes();
            salesInvoiceList.Clear();
            this.frm = frm1;
        }

        private void frmSalesInvoice_Load(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            if (!proc.LoadInitialData(ref dt))
            {
                MessageBox.Show("Unable to connect to server"); 
            }
            else
            {
                dgvDRList.DataSource = dt;
                dgvDRList.ClearSelection(); // remove first highlighted row in datagrid
            }

            txtSalesInvoiceNumber.Focus();
        }

        private void frmSalesInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //Main main = new Main();
            //main.Show();
        }

        private void ConfigureGrids()
        {
            //GRID 1
            //dgvDRList.AutoGenerateColumns = false;
            dgvDRList.AllowUserToAddRows = false;
            dgvDRList.AllowUserToResizeColumns = false;
            dgvDRList.AllowUserToDeleteRows = false;
            dgvDRList.AllowUserToOrderColumns = false;
            dgvDRList.AllowUserToResizeRows = false;
            dgvDRList.AllowUserToAddRows = false;
            dgvDRList.ScrollBars = ScrollBars.Vertical;
            dgvDRList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Rename datagrid columns programmatically
            dgvDRList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDRList.ColumnCount = 5; //COUNT OF COLUMNS THAT WILL DISPLAY IN GRID

            //Column names and width setup
            dgvDRList.Columns[0].Name = "QUANTITY";
            dgvDRList.Columns[0].Width = 70;
            dgvDRList.Columns[0].DataPropertyName = "Quantity";

            dgvDRList.Columns[1].Name = "BATCH NAME";
            dgvDRList.Columns[1].Width = 150;
            dgvDRList.Columns[1].DataPropertyName = "batch"; //this must be the actual table name in sql

            dgvDRList.Columns[2].Name = "CHECK NAME";
            dgvDRList.Columns[2].Width = 200;
            dgvDRList.Columns[2].DataPropertyName = "chequename";

            dgvDRList.Columns[3].Name = "CHECK TYPE";
            dgvDRList.Columns[3].Width = 104;
            dgvDRList.Columns[3].DataPropertyName = "ChkType";

            dgvDRList.Columns[4].Name = "DELIVERY DATE";
            dgvDRList.Columns[4].Width = 500;
            dgvDRList.Columns[4].DataPropertyName = "deliverydate";

            //GRID 2
            //dgvDRList.AutoGenerateColumns = true;
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

            dgvListToProcess.Columns[0].Name = "QTY";
            dgvListToProcess.Columns[0].Width = 50;
            dgvListToProcess.Columns[0].DataPropertyName = "OrderQuantity";

            dgvListToProcess.Columns[1].Name = "BATCH";
            dgvListToProcess.Columns[1].Width = 100;
            dgvListToProcess.Columns[1].DataPropertyName = "BatchName"; //this must be the actual table name in sql

            dgvListToProcess.Columns[2].Name = "CHECK NAME";
            dgvListToProcess.Columns[2].Width = 180;
            dgvListToProcess.Columns[2].DataPropertyName = "CheckName";

            dgvListToProcess.Columns[3].Name = "DR LIST";
            dgvListToProcess.Columns[3].Width = 400;
            dgvListToProcess.Columns[3].DataPropertyName = "DRList";

            dgvListToProcess.Columns[4].Name = "CHECK TYPE";
            dgvListToProcess.Columns[4].Width = 50;
            dgvListToProcess.Columns[4].DataPropertyName = "checktype";

            dgvListToProcess.Columns[5].Name = "INVOICE DATE";
            dgvListToProcess.Columns[5].Width = 80;
            dgvListToProcess.Columns[5].DataPropertyName = "SalesInvoiceDate";

            dgvListToProcess.Columns[6].Name = "UNIT PRICE";
            dgvListToProcess.Columns[6].DefaultCellStyle.Format = "#,0.00##";
            dgvListToProcess.Columns[6].Width = 100;
            dgvListToProcess.Columns[6].DataPropertyName = "UnitPrice";

            dgvListToProcess.Columns[7].Name = "AMOUNT";
            dgvListToProcess.Columns[7].DefaultCellStyle.Format = "#,0.00##";
            dgvListToProcess.Columns[7].Width = 500;
            dgvListToProcess.Columns[7].DataPropertyName = "LineTotalAmount";

        }

        private void dgvDRList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void btnViewSelected_Click(object sender, EventArgs e)
        {

            pProcessSelectedDRList();

        }

        private void pProcessSelectedDRList()
        {

            if (dgvDRList.SelectedRows != null && dgvDRList.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvDRList.SelectedRows)
                {
                    SalesInvoiceModel line = new SalesInvoiceModel();

                    line.Batch = row.Cells["batch Name"].Value.ToString();
                    line.checkName = row.Cells["check name"].Value.ToString();
                    line.checkType = row.Cells["check type"].Value.ToString();
                    line.salesInvoiceDate = DateTime.Parse(dtpInvoiceDate.Value.ToShortDateString());
                    line.deliveryDate = DateTime.Parse(row.Cells["Delivery Date"].Value.ToString());
                    line.Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    line.drList = proc.GetDRList(line.Batch, line.checkType, line.deliveryDate);
                    line.unitPrice = double.Parse(proc.GetUnitPrice(line.checkName).ToString("#.##"));
                    line.lineTotalAmount = Math.Round(line.Quantity * line.unitPrice, 2);
                    salesInvoiceList.Add(line);
                    
                }
                
                //created 'list' variable column sorting by line for datagrid view 
                var sortedList = salesInvoiceList
                    .Select
                    (i => new { i.Quantity, i.Batch, i.checkName, i.drList, i.checkType, i.salesInvoiceDate, i.unitPrice, i.lineTotalAmount })
                    
                    .ToList();

                dgvListToProcess.DataSource = sortedList;
                dgvListToProcess.ClearSelection();
                
                ProcessServices_Nelson proc1 = new ProcessServices_Nelson();

                if (!proc1.UpdateTempTable(salesInvoiceList))
                {
                    MessageBox.Show("Unable to connect to server. \r\n" + proc1.errorMessage);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Please select at least one record");
            }

        }

        private void btnPrintSalesInvoice_Click(object sender, EventArgs e)
        {

            if (!p.ValidateInputFields(txtSalesInvoiceNumber.Text.ToString(), cbPreparedBy.Text.ToString(), cbCheckedBy.Text.ToString(), cbApprovedBy.Text.ToString()))
            {
                MessageBox.Show("Please supply values in blank field(s)");
            }
            else if(dgvListToProcess.Rows.Count == 0)
            {
                MessageBox.Show("Please select record from Batch List.");
            }
            else
            {

                DialogResult result = MessageBox.Show("This will process Sales Invoice on selected DR's. \r\n Select 'YES' to proceed.", "Confirmation", MessageBoxButtons.YesNo);
                
                if (result == DialogResult.Yes)
                {
                    //gSalesInvoiceList = salesInvoiceList;
                    gSalesInvoiceDate = dtpInvoiceDate.Value;
                    gSalesInvoiceGeneratedBy = lblUserName.Text.ToString();
                    gSalesinvoiceCheckedBy = cbCheckedBy.Text.ToString();
                    gSalesInvoiceApprovedBy = cbApprovedBy.Text.ToString();
                    gSalesInvoiceNumber = double.Parse(txtSalesInvoiceNumber.Text.ToString());
                    gSalesInvoiceSubtotalAmount = double.Parse(salesInvoiceList.Sum(x => x.lineTotalAmount).ToString());
                    gSalesInvoiceVatAmount = p.GetVatAmount(gSalesInvoiceSubtotalAmount);
                    gSalesInvoiceNetOfVatAmount = p.GetNetOfVatAmount(gSalesInvoiceSubtotalAmount);


                    
                    ///Sort Sales Invoice By Batch before saving and Printing
                    var sortedList = salesInvoiceList.OrderBy(x => x.Batch).ToList();


                    ///Update Database
                    if (!proc.UpdateSalesInvoiceHistory(sortedList))
                    {
                        MessageBox.Show("Error upon updating to server. (proc.UpdateSalesInvoiceHistory) \r\n" + proc.errorMessage);
                        return;
                    }
                    //MessageBox.Show("Number of rows affected: " + proc.RowNumbersAffected.ToString());


                    //Install Fastmember from nuGet for Fast (List to Datatable) Conversion
                    DataTable dt = new DataTable();
                    using (var reader = ObjectReader.Create(sortedList))
                    {
                        dt.Load(reader);
                    }

                    ///Supply datatable from the list converted
                    gReportDT = dt;

                    frmReportViewer crForm = new frmReportViewer();
                    crForm.Show();
                    RefreshView();

                }

            }

        }

        private void txtSalesInvoiceNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalesInvoiceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (p.IsKeyPressedNumeric( ref sender, ref e))
            {
                e.Handled = true;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchText();
           
        }

        private void btnReloadDrList_Click(object sender, EventArgs e)
        {

            RefreshView();
        }

        private void RefreshView()
        {
            salesInvoiceList.Clear();
            txtSearch.Text = "";
            txtSalesInvoiceNumber.Text = "";
            txtSalesInvoiceNumber.Focus();
            cbPreparedBy.Text = "";
            cbCheckedBy.Text = "";
            cbApprovedBy.Text = "";
            
            DataTable dt = new DataTable();
            proc.LoadInitialData(ref dt);
            dgvDRList.DataSource = dt;
            dgvDRList.ClearSelection();


            var sortedList = salesInvoiceList
                     .Select
                     (i => new { i.Quantity, i.Batch, i.checkName, i.drList, i.checkType, i.salesInvoiceDate, i.unitPrice, i.lineTotalAmount })
                     .ToList();

            dgvListToProcess.DataSource = sortedList;
            dgvListToProcess.ClearSelection();


        }

        private void SearchText()
        {
            DataTable dt = new DataTable();
            if (txtSearch.Text is null || txtSearch.Text == "")
            {
                MessageBox.Show("Please input batch number to search");
            }
            else
            {
                if (!proc.BatchSearch(txtSearch.Text, ref dt))
                {
                    MessageBox.Show("Unable to connect to server. (proc.BatchSearch)\r\n" + proc.errorMessage);
                    return;
                }

                var check = dt.Rows.Count != 0 ? dgvDRList.DataSource = dt : MessageBox.Show("No results found");
                txtSearch.Focus();
                txtSearch.SelectAll();
                dgvDRList.ClearSelection();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FillComboBoxes()
        {
            DataTable dt = new DataTable();
            if (!proc.GetUserNames(ref dt))
            {
                MessageBox.Show("Unable to connect to server. \r\n" + proc.errorMessage);
            }

            
            _ = dt.Rows.Count != 0 ? cbPreparedBy.DataSource = dt : cbPreparedBy.DataSource = null;
            cbPreparedBy.BindingContext = new BindingContext();
            cbPreparedBy.DisplayMember = "UserName";
            cbPreparedBy.SelectedIndex = -1;

            _ = dt.Rows.Count != 0 ? cbCheckedBy.DataSource = dt : cbCheckedBy.DataSource = null;
            cbCheckedBy.BindingContext = new BindingContext();
            cbCheckedBy.DisplayMember = "UserName";
            cbCheckedBy.SelectedIndex = -1;

            _ = dt.Rows.Count != 0 ? cbApprovedBy.DataSource = dt : cbApprovedBy.DataSource = null;
            cbApprovedBy.BindingContext = new BindingContext();
            cbApprovedBy.DisplayMember = "UserName";
            cbApprovedBy.SelectedIndex = -1;

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchText();
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            frmMessageInput xfrm = new frmMessageInput();
            xfrm.labelMessage = "Input Sales Invoice Number:";
            DialogResult result = xfrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ReprintSalesInvoice(int.Parse(xfrm.userInput));
            }
        }

        public void ReprintSalesInvoice(int salesInvoiceNumber)
        {

            //get Finished Sales Inbvoice details if exist
            DataTable siFinishedDT = new DataTable();
            if (!proc.SalesInvoiceExist(salesInvoiceNumber, ref siFinishedDT))
            {
                MessageBox.Show("Unable to find provided Sales Invoice Number. (proc.SalesInvoiceExist)\r\n" + proc.errorMessage);
                return;
            }

            //Supply Global Variables based on fetched data
            foreach (DataRow row in siFinishedDT.Rows)
            {
                gCustomerCode = row.Field<string>("CustomerCode");
                gSalesInvoiceNumber = row.Field<double>("SalesInvoiceNumber");
                gSalesInvoiceDate = row.Field<DateTime>("SalesInvoiceDateTime");
                gSalesInvoiceGeneratedBy = row.Field<string>("GeneratedBy");
                gSalesinvoiceCheckedBy = row.Field<string>("CheckedBy");
                gSalesInvoiceApprovedBy = row.Field<string>("ApprovedBy");
                gSalesInvoiceSubtotalAmount = row.Field<double>("TotalAmount");
                gSalesInvoiceVatAmount = row.Field<double>("VatAmount");
                gSalesInvoiceNetOfVatAmount = row.Field<double>("NetOfVatAmount");
            }

            //Get Sales Invoice List Details to be supplied to Global Report Datatable
            DataTable siListDT = new DataTable();
            if (!proc.GetOldSalesInvoiceList(salesInvoiceNumber, ref siListDT))
            {
                MessageBox.Show("Unable to connect to server. (proc.SalesInvoiceExist)\r\n" + proc.errorMessage);
                return;
            }
            gReportDT = siListDT;

            
            frmReportViewer crForm = new frmReportViewer();
            crForm.Show();

        }



    }

    

    

}
