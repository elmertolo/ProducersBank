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

namespace ProducersBank
{
    public partial class frmSalesInvoice : Form
    {
        public frmSalesInvoice()
        {
            InitializeComponent();
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
                }
            }
        }

        private void frmSalesInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
