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

namespace ProducersBank
{
    public partial class frmSalesInvoice : Form
    {
        public frmSalesInvoice()
        {
            InitializeComponent();
            ConfigureGrids();
        }

        private void frmSalesInvoice_Load(object sender, EventArgs e)
        {
            ProcessServices_Nelson proc = new ProcessServices_Nelson();
            if (!proc.OpenDB())
            {
                MessageBox.Show("Unable to connect to Server");
                
            }
            else
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
            }
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
            dgvDRList.Columns[0].Name = "BATCH";
            dgvDRList.Columns[0].Width = 150;
            dgvDRList.Columns[0].DataPropertyName = "Batch"; //this must be the actual table name in sql

            dgvDRList.Columns[1].Name = "CHECK NAME";
            dgvDRList.Columns[1].Width = 200;
            dgvDRList.Columns[1].DataPropertyName = "chequename";

            dgvDRList.Columns[2].Name = "CHECK TYPE";
            dgvDRList.Columns[2].Width = 104;
            dgvDRList.Columns[2].DataPropertyName = "ChkType";

            dgvDRList.Columns[3].Name = "DELIVERY DATE";
            dgvDRList.Columns[3].Width = 100;
            dgvDRList.Columns[3].DataPropertyName = "deliverydate";

            dgvDRList.Columns[4].Name = "QUANTITY";
            dgvDRList.Columns[4].Width = 1000;
            dgvDRList.Columns[4].DataPropertyName = "Quantity";

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
            dgvListToProcess.ColumnCount = 6; //COUNT OF COLUMNS THAT WILL DISPLAY IN GRID

            //Column names and width setup
            dgvListToProcess.Columns[0].Name = "BATCH";
            dgvListToProcess.Columns[0].Width = 100;
            dgvListToProcess.Columns[0].DataPropertyName = "Batch"; //this must be the actual table name in sql

            dgvListToProcess.Columns[1].Name = "DR LIST";
            dgvListToProcess.Columns[1].Width = 400;
            dgvListToProcess.Columns[1].DataPropertyName = "drlist";

            dgvListToProcess.Columns[2].Name = "CHECK NAME";
            dgvListToProcess.Columns[2].Width = 180;
            dgvListToProcess.Columns[2].DataPropertyName = "checkname";

            dgvListToProcess.Columns[3].Name = "CHECK TYPE";
            dgvListToProcess.Columns[3].Width = 50;
            dgvListToProcess.Columns[3].DataPropertyName = "checktype";

            dgvListToProcess.Columns[4].Name = "DELIVERY DATE";
            dgvListToProcess.Columns[4].Width = 100;
            dgvListToProcess.Columns[4].DataPropertyName = "deliverydate";

            dgvListToProcess.Columns[5].Name = "QUANTITY";
            dgvListToProcess.Columns[5].Width = 1000;
            dgvListToProcess.Columns[5].DataPropertyName = "Quantity";

        }

        private void dgvDRList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblSearchBatchNo_Click(object sender, EventArgs e)
        {

        }

        private void btnViewSelected_Click(object sender, EventArgs e)
        {


            pProcessSelectedOnDRList();

        }

        private void pProcessSelectedOnDRList()
        {

            if (dgvDRList.SelectedRows != null && dgvDRList.SelectedRows.Count > 0)
            {
                List<SalesInvoiceModel> siList = new List<SalesInvoiceModel>();
                SalesInvoiceModel line = new SalesInvoiceModel();

                foreach (DataGridViewRow row in dgvDRList.SelectedRows)
                {
                    line.batch = row.Cells["batch"].Value.ToString();
                    line.checkName = row.Cells["check name"].Value.ToString();
                    line.checkType = row.Cells["check type"].Value.ToString();
                    line.deliveryDate = DateTime.Parse(row.Cells["delivery Date"].Value.ToString());
                    line.quantity = int.Parse(row.Cells["quantity"].Value.ToString());

                    ProcessServices_Nelson proc = new ProcessServices_Nelson();
                    if (!proc.OpenDB())
                    {
                        MessageBox.Show("Unable to connect to server.");
                    }
                    else
                    {
                        line.drList = proc.GetDRList(line.batch, line.checkType, line.deliveryDate);
                    }

                    siList.Add(line);
                    

                }
                dgvListToProcess.DataSource = siList;
                dgvListToProcess.ClearSelection();

            }
        }


       











    }

    

}
