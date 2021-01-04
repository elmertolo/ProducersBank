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
            if (RecentBatch.report == "DR")
            {
                DeliveryReceipt crystalReport = new DeliveryReceipt();
                this.crystalReportViewer1.ReportSource = crystalReport;
                this.crystalReportViewer1.RefreshReport();

            }
            else if (RecentBatch.report == "STICKER")
            {
                Stickers stickerReport = new Stickers();
                this.crystalReportViewer1.ReportSource = stickerReport;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (RecentBatch.report == "Packing")
            {
                PackingReport crystalReport = new PackingReport();
                this.crystalReportViewer1.ReportSource = crystalReport;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (RecentBatch.report == "SalesInvoice")
            {
                SalesInvoice crystalReport = new SalesInvoice();
                this.crystalReportViewer1.ReportSource = crystalReport;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (DeliveryReport.report == "DR")
            {
                DeliveryReceipt crystalReport = new DeliveryReceipt();
                this.crystalReportViewer1.ReportSource = crystalReport;
                this.crystalReportViewer1.RefreshReport();
            }


        }
    }
}
