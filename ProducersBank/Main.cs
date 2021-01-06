using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProducersBank.GlobalVariables;

namespace ProducersBank
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            

        }

        private void btnDR_Click(object sender, EventArgs e)
        {
            DeliveryReport dr = new DeliveryReport();
            dr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecentBatch rb = new RecentBatch();
            rb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSalesInvoice si = new frmSalesInvoice();
            si.Show();
            this.Hide();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
