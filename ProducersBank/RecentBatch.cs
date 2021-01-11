using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using ProducersBank.Models;
using ProducersBank.Services;

namespace ProducersBank
{
    public partial class RecentBatch : Form
    {
        Main frm;
        public static string report = "";
        ProcessServices proc = new ProcessServices();
         List<TempModel> tempRecent = new List<TempModel>();
        List<TempModel> batchTemp = new List<TempModel>();
        public RecentBatch(Main frm1)
        {
            InitializeComponent();
            this.frm = frm1;
        }



        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tempRecent.Clear();
            proc.GetDRDetails(txtRecentBatch.Text, tempRecent);
            tempRecent.Clear();
            proc.GetStickerDetails(tempRecent, txtRecentBatch.Text);

            //BindingSource checkBind = new BindingSource();
            //checkBind.DataSource = tempRecent;
            //dgvDRList.DataSource = checkBind;
            printDRToolStripMenuItem.Enabled = true;
            MessageBox.Show("Batch :" + txtRecentBatch.Text + " has been generated!!!");
        }

        private void deliveryReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "DR";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        //private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Main m = new Main();
        //    m.Show();
        //}

        private void printDRToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stickersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "STICKER";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void packingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "Packing";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "SalesInvoice";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void RecentBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //Form f = new Main();
            //f.Show();
        }

        private void RecentBatch_Load(object sender, EventArgs e)
        {
            txtRecentBatch.Focus();
        }

        private void txtRecentBatch_TextChanged(object sender, EventArgs e)
        {
            batchTemp.Clear();
            proc.DisplayAllBatches(txtRecentBatch.Text,batchTemp);
            DataTable dt = new DataTable();

            dt.Clear();

            dt.Columns.Add("Batch");
            dt.Columns.Add("Cheque Name");
            dt.Columns.Add("ChkType");
            dt.Columns.Add("Delivery Date");
            dt.Columns.Add("Quantity");
          

            batchTemp.ForEach(r =>
            {
                dt.Rows.Add(new object[] { r.Batch, r.ChequeName, r.ChkType, r.DeliveryDate.ToString("yyyy-MM-dd"), r.Qty });
            });
            
            dgvDRList.DataSource = dt;

            dgvDRList.Columns[1].Width = 200;
            dgvDRList.Columns[3].Width = 130;
        }

        private void dgvDRList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowindex = dgvDRList.CurrentCell.RowIndex;
            int columnindex = dgvDRList.CurrentCell.ColumnIndex;

            // student.Stud_ID = int.Parse(dtgList.Rows[rowindex].Cells[columnindex].Value.ToString());
            txtRecentBatch.Text = dgvDRList.Rows[rowindex].Cells[0].Value.ToString();
        }
    }
}
