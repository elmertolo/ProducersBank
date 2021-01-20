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
using ProducersBank.Services;
using static ProducersBank.GlobalVariables;
using ProducersBank.Models;
using ProducersBank.Procedures;


namespace ProducersBank
{
    public partial class frmReportViewer : Form
    {
        //List<SalesInvoiceModel> siList = new List<SalesInvoiceModel>();
        
        ProcessServices_Nelson proc = new ProcessServices_Nelson();
        

        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void crViewer_Load(object sender, EventArgs e)
        {

            crViewer.ShowRefreshButton = false;
            crViewer.ShowCloseButton = false;
            crViewer.ShowGroupTreeButton = false;
            
            //Supply report parameters
            //Supply database /  table credetials dynamically
            p.setCrystalReportsDBInfo(ref gCrystalDocument);
            
            if (gViewReportFirst == 1)
            {
                crViewer.ReportSource = gCrystalDocument;
            }
            else
            {
                gCrystalDocument.PrintToPrinter(1, false, 0, 0);
                this.Close();
            }

        }

    }

}
