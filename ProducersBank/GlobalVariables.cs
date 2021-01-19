using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using ProducersBank.Models;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace ProducersBank
{ 
    public static class GlobalVariables
    {
        
        /// <summary>
        /// Global Variables to be supplied upon application login
        /// </summary>
        public static ClientListModel gClient = new ClientListModel();
        public static UserListModel gUser = new UserListModel();
        public static SalesInvoiceFinishedModel gSalesInvoiceFinished = new SalesInvoiceFinishedModel();

        //Report Global Variables (Crystal Report Prerequisites)
        public static ReportDocument gCrystalDocument = new ReportDocument();
        public static DataTable gReportDT;

        /// <summary>
        /// This variables is used for SalesInvoice Processes only.
        /// </summary
        //variables from appconfig file=================================================
        //public static List<SalesInvoiceModel> gSalesInvoiceList = new List<SalesInvoiceModel>();

        public static int gViewReportFirst = int.Parse(ConfigurationManager.AppSettings["ViewReportFirst"]);
        public static string gHeaderReportCompanyName = ConfigurationManager.AppSettings["SIHeaderReportCompanyName"]; //"PRODUCERS BANK";
        public static string gSIheaderReportTitle = ConfigurationManager.AppSettings["SIheaderReportTitle"]; //"SALES INVOICE";
        public static string gSIHeaderReportAddress1 = ConfigurationManager.AppSettings["SIHeaderReportAddress1"]; //"6197 Ayala Avenue";
        public static string gSIHeaderReportAddress2 = ConfigurationManager.AppSettings["SIHeaderReportAddress2"]; //"Salcedo Village";
        public static string gSIHeaderReportAddress3 = ConfigurationManager.AppSettings["SIHeaderReportAddress3"]; //"Makati City";
        //resettable variables
     
      
        //=============================================================================

    }
}
