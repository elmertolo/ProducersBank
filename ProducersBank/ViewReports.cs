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
using ProducersBank.Services;
using MySql.Data.MySqlClient;

namespace ProducersBank
{
    public partial class ViewReports : Form
    {
        
        public ViewReports()
        {
            InitializeComponent();
        }
        ProcessServices process = new ProcessServices();
        
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void ViewReports_Load(object sender, EventArgs e)
        {
          
            if (RecentBatch.report == "DR")
            {
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from producers_tempdatadr", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
               
                this.crystalReportViewer1.ReportSource = cryRpt;
                this.crystalReportViewer1.RefreshReport();
                 
            }
            else if (RecentBatch.report == "STICKER" || DeliveryReport.report == "STICKER")
            {
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from producers_sticker", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
           
                this.crystalReportViewer1.ReportSource =cryRpt;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (RecentBatch.report == "Packing" || DeliveryReport.report == "Packing")
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
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from producers_tempdatadr", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
              //  DeliveryReceipt crystalReport = new DeliveryReceipt();
                this.crystalReportViewer1.ReportSource = cryRpt;
                this.crystalReportViewer1.RefreshReport();
            }


        }
    }
}
