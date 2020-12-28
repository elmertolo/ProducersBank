using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace ProducersBank
{
    public static class GlobalVariables
    {
        // used variables for SALES INVOICE report
        public static int gViewReportFirst;
        public static DataTable gReportDT = new DataTable();
        public static string gHeaderReportTitle = "SALES INVOICE";
        public static string gHeaderReportAddress1 = "6197 Ayala Avenue";
        public static string gHeaderReportAddress2 = "SALCEDO VILLAGE";
        public static string gHeaderReportAddress3 = "MAKATI CITY";
        public static string gHeaderReportCompanyName = "PRODUCERS BANK";

    }
}
