using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;


namespace ProducersBank
{
    public partial class ViewReports : Form
    {
        public ViewReports()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ViewReports_Load(object sender, EventArgs e)
        {

            DeliveryReceipt crystalReport = new DeliveryReceipt();
           // Stickers stickerReport = new Stickers();
            //   Customers dsCustomers = GetData();
            //    crystalReport.SetDataSource(dsCustomers);
            
            
            this.crystalReportViewer1.ReportSource = crystalReport;
            this.crystalReportViewer1.RefreshReport();
           

        }
    }
}
