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

namespace ProducersBank
{
    public partial class frmSalesInvoice : Form
    {

        List<SalesInvoiceModel> SalesInvoiceList = new List<SalesInvoiceModel>();
        ProcessServices_Nelson proc = new ProcessServices_Nelson();
        public frmSalesInvoice()
        {
            InitializeComponent();
            ConfigureGrids();
            SalesInvoiceList.Clear();
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
            this.Hide();
            Main main = new Main();
            main.Show();
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
            dgvListToProcess.Columns[6].Width = 100;
            dgvListToProcess.Columns[6].DataPropertyName = "UnitPrice";

            dgvListToProcess.Columns[7].Name = "AMOUNT";
            dgvListToProcess.Columns[7].Width = 500;
            dgvListToProcess.Columns[7].DataPropertyName = "Amount";

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

                    line.batchName = row.Cells["batch Name"].Value.ToString();
                    line.checkName = row.Cells["check name"].Value.ToString();
                    line.checkType = row.Cells["check type"].Value.ToString();
                    line.salesInvoiceDate = DateTime.Parse(dtpInvoiceDate.Value.ToShortDateString());
                    line.deliveryDate = DateTime.Parse(row.Cells["Delivery Date"].Value.ToString());
                    line.orderQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    line.drList = proc.GetDRList(line.batchName, line.checkType, line.deliveryDate);
                    line.unitPrice = proc.GetUnitPrice(line.checkName);

                    SalesInvoiceList.Add(line);
                    
                }
                
                //created list variable for column sorting
                var sortedList = SalesInvoiceList
                    .Select
                    (i => new { i.orderQuantity, i.batchName, i.checkName, i.drList, i.checkType, i.salesInvoiceDate, i.unitPrice })
                    .ToList();

                dgvListToProcess.DataSource = sortedList;
                dgvListToProcess.ClearSelection();
                
                ProcessServices_Nelson proc1 = new ProcessServices_Nelson();

                if (!proc1.UpdateTempTable(SalesInvoiceList))
                {
                    MessageBox.Show("Unable to connect to server. \r\n" + proc1.errorMessage);
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
            else
            {
                gReportDT = SalesInvoiceList;
                gSalesInvoiceDate = dtpInvoiceDate.Value;
                gPreparedBy = cbPreparedBy.Text.ToString();
                gCheckedBy = cbCheckedBy.Text.ToString();
                gApprovedBy = cbApprovedBy.Text.ToString();
                gSalesInvoiceNumber = double.Parse(txtSalesInvoiceNumber.Text.ToString());

                //if (!p.UpdateSalesInvoiceFields())
                //{
                //    MessageBox.Show("Error upon updating to server. " + p.errorMessage);
                //    return;
                //}

                frmReportViewer crForm = new frmReportViewer();
                crForm.Show();
                this.Hide();
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
    }

    

    

}
