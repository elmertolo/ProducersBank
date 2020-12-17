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
            dataGridView1.DataSource = checkBind;
        }

        private void deliveryReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

       
    }
}
