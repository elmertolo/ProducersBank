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

namespace ProducersBank.Forms
{
    public partial class frmDocStamp : Form
    {
        Main frm1;
        public frmDocStamp(Main frm)
        {
            InitializeComponent();
            this.frm1 = frm;
        }
        ProcessServices proc = new ProcessServices();
        List<SalesInvoiceModel> listofSI = new List<SalesInvoiceModel>();
        List<DocStampModel> docstamp = new List<DocStampModel>();
        private void frmDocStamp_Load(object sender, EventArgs e)
        {
            proc.ListofProcessSI(listofSI);
            DataTable dt = new DataTable();
            dt.Columns.Add("Sales Invoice Date");
            dt.Columns.Add("Sales Invoice Number");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Type");
            dt.Columns.Add("Cheque Name");
            dt.Columns.Add("Batch");

            listofSI.ForEach(a =>
            {
                dt.Rows.Add(new object[] { a.salesInvoiceDate.ToString("yyyy-MM-dd"), a.salesInvoiceNumber, a.Quantity,a.checkType, a.checkName, a.Batch });
            });
            DgvDSalesInvoice.DataSource = dt;

            DgvDSalesInvoice.Columns[0].Width = 150;
            DgvDSalesInvoice.Columns[3].Width =150 ;
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvDSalesInvoice.SelectedRows != null && DgvDSalesInvoice.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in DgvDSalesInvoice.SelectedRows)
                {
                    DocStampModel doc = new DocStampModel
                    {

                        DocStampDate = dtpDocDate.Value,
                        batches = row.Cells["Batch"].Value.ToString(),
                        SalesInvoiceNumber = proc.ContcatSalesInvoice(row.Cells["Batch"].Value.ToString(), row.Cells["Type"].Value.ToString(), dtpDocDate.Value),
                       
                        //line.Batch = row.Cells["batch Name"].Value.ToString();
                        //line.checkName = row.Cells["check name"].Value.ToString();
                        //line.checkType = row.Cells["check type"].Value.ToString();
                        //line.salesInvoiceDate = DateTime.Parse(dtpInvoiceDate.Value.ToShortDateString());
                        //line.deliveryDate = DateTime.Parse(row.Cells["Delivery Date"].Value.ToString());
                        //line.Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                        //line.drList = proc.GetDRList(line.Batch, line.checkType, line.deliveryDate);
                        //line.unitPrice = double.Parse(proc.GetUnitPrice(line.checkName).ToString("#.##"));
                        //line.lineTotalAmount = Math.Round(line.Quantity * line.unitPrice, 2);
                        // salesInvoiceList.Add(line);
                    };
                    docstamp.Add(doc);
                }

                //created 'list' variable column sorting by line for datagrid view 
                //var sortedList = docstamp
                //    .Select
                //    (i => new { i.Quantity, i.Batch, i.checkName, i.drList, i.checkType, i.salesInvoiceDate, i.unitPrice, i.lineTotalAmount })

                //    .ToList();

                //dgvOutput.DataSource = sortedList;
                dgvOutput.ClearSelection();

            }
            else
            {
                MessageBox.Show("Please select at least one record");
            }
        }
    }
}
