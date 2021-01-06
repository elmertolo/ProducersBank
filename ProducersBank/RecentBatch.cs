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
        public static string report = "";
        ProcessServices proc = new ProcessServices();
         List<TempModel> tempRecent = new List<TempModel>();
        public RecentBatch()
        {
            InitializeComponent();
        }


        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proc.GetDRDetails(txtRecentBatch.Text, tempRecent);
            BindingSource checkBind = new BindingSource();
            checkBind.DataSource = tempRecent;
            dgvDRList.DataSource = checkBind;
            printDRToolStripMenuItem.Enabled = true;
        }

        private void deliveryReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "DR";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

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
            this.Hide();
            Form f = new Main();
            f.Show();
        }
    }
}
