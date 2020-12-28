using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using static ProducersBank.GlobalVariables;

namespace ProducersBank
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void crViewer_Load(object sender, EventArgs e)
        {
            //string reportPath = Directory.GetCurrentDirectory().ToString() + @"\SalesInvoice.rpt" ;
            string reportPath = @"C:\Users\Bon Bon\source\repos\Producers Bank Main\ProducersBank\ProducersBank\SalesInvoice.rpt";

            if (!File.Exists(reportPath))
            {
                throw (new Exception("Unable to locate report file: \r\n" + reportPath));
            }

            ReportDocument crystalDocument = new ReportDocument();
            crystalDocument.Load(reportPath);
            crystalDocument.SetDataSource(gReportDT);

            crViewer.ShowRefreshButton = false;
            crViewer.ShowCloseButton = false;
            crViewer.ShowGroupTreeButton = false;

            if (gHeaderReportTitle != null)
            {
                crystalDocument.SetParameterValue("HeaderReportTitle", gHeaderReportTitle);
            }
            if (gHeaderReportAddress1 != null)
            {
                crystalDocument.SetParameterValue("HeaderReportAddress1", gHeaderReportAddress1);
            }
            if (gHeaderReportAddress2 != null)
            {
                crystalDocument.SetParameterValue("HeaderReportAddress2", gHeaderReportAddress2);
            }
            if (gHeaderReportAddress3 != null)
            {
                crystalDocument.SetParameterValue("HeaderReportAddress3", gHeaderReportAddress3);
            }
            if (gHeaderReportCompanyName != null)
            {
                crystalDocument.SetParameterValue("HeaderReportCompanyName", gHeaderReportCompanyName);
            }

            











            if (gViewReportFirst == 1)
            {
                crViewer.ReportSource = crystalDocument;
            }
            else
            {
                crystalDocument.PrintToPrinter(1, false, 0, 0);
                this.Close();
            }


        }

        
    }
}
