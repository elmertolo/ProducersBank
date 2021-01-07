using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using ProducersBank.Models;

namespace ProducersBank
{
    public static class GlobalVariables
    {
        //this is where the main table name used by the bank will be stored
        public static string gHistoryTable = "Producers_History";



        
        /// <summary>
        /// This variables is used for SalesInvoice Processes only.
        /// </summary>
        //variables from appconfig file=================================================
        public static List<SalesInvoiceModel> gReportDT = new List<SalesInvoiceModel>();
        public static int gViewReportFirst = int.Parse(ConfigurationManager.AppSettings["ViewReportFirst"]);
        public static string gSIHeaderReportCompanyName = ConfigurationManager.AppSettings["SIHeaderReportCompanyName"]; //"PRODUCERS BANK";
        public static string gSIheaderReportTitle = ConfigurationManager.AppSettings["SIheaderReportTitle"]; //"SALES INVOICE";
        public static string gSIHeaderReportAddress1 = ConfigurationManager.AppSettings["SIHeaderReportAddress1"]; //"6197 Ayala Avenue";
        public static string gSIHeaderReportAddress2 = ConfigurationManager.AppSettings["SIHeaderReportAddress2"]; //"Salcedo Village";
        public static string gSIHeaderReportAddress3 = ConfigurationManager.AppSettings["SIHeaderReportAddress3"]; //"Makati City";
        //resettable variables
        public static double gSalesInvoiceNumber;
        public static DateTime gSalesInvoiceDate;
        public static double gSubtotalAmount;
        public static double gVatAmount;
        public static double gNetOfVatAmount;
        public static string gPreparedBy;
        public static string gCheckedBy;
        public static string gApprovedBy;

        //=============================================================================

    }
}
