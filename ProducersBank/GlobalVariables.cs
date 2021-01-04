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
        // used variables for SALES INVOICE report
        public static int gViewReportFirst = 1;
        //public static DataTable gReportDT = new DataTable();
        public static List<SalesInvoiceModel> gReportDT = new List<SalesInvoiceModel>();
        public static string gHeaderReportCompanyName = "PRODUCERS BANK";
        public static string gHeaderReportTitle = "SALES INVOICE";
        public static string gHeaderReportAddress1 = "6197 Ayala Avenue";
        public static string gHeaderReportAddress2 = "Salcedo Village";
        public static string gHeaderReportAddress3 = "Makati City";
        public static DateTime gSalesInvoiceDate;
        public static string gPreparedBy;
        public static string gCheckedBy;
        public static string gApprovedBy;



    }
}
