using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProducersBank.Models;
using static ProducersBank.GlobalVariables;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace ProducersBank.Procedures
{
    public static class p
    {

        public static bool IsKeyPressedNumeric(ref object sender , ref KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') || ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))) 
            {
                return true;
            }
            return false;
            
        }

        public static bool ValidateInputFields(string salesInvoiceNumber, string checkedBy, string approvedBy)
        {
            if (string.IsNullOrWhiteSpace(checkedBy) || string.IsNullOrWhiteSpace(approvedBy))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

       public static double GetVatAmount(double subTotal)
        {
            return Math.Round(subTotal / 1.12 * .12);
        }

        public static double GetNetOfVatAmount(double subTotal)
        {
            return Math.Round(subTotal / 1.12);
        }

        public static void setCrystalReportsDBInfo(ref ReportDocument rpt)
        {
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table crystalTtables in rpt.Database.Tables)
            {
                logoninfo = crystalTtables.LogOnInfo;
                logoninfo.ReportName = rpt.Name;
                logoninfo.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["ServerName"].ToString();
                logoninfo.ConnectionInfo.DatabaseName = ConfigurationManager.AppSettings["DatabaseName"].ToString();
                logoninfo.ConnectionInfo.UserID = ConfigurationManager.AppSettings["UserId"].ToString();
                logoninfo.ConnectionInfo.Password = ConfigurationManager.AppSettings["Password"].ToString();
                logoninfo.TableName = crystalTtables.Name;
                crystalTtables.ApplyLogOnInfo(logoninfo);
                crystalTtables.Location = crystalTtables.Name;
            }
        }

        //public static void SupplyBankVariables(string bankName, ref DataTable dt)
        //{


            //if (bankName == "United Coconut Planters Bank")
            //{

            //}
            //if (bankName == "Unionbank of the Philippines")
            //{

            //}
            //if (bankName == "Sterling Bank of Asia")
            //{

            //}
            //if (bankName == "Security Bank Savings")
            //{

            //}
            //if (bankName == "Security Bank Corporation")
            //{

            //}
            //if (bankName == "Rural Bank of Central Pangasinan")
            //{

            //}
            //if (bankName == "Rizal Commercial Banking Corporation")
            //{

            //}
            //if (bankName == "Real Bank")
            //{

            //}
            //if (bankName == "RCBC Savings Bank")
            //{

            //}
            //if (bankName == "Producers Bank")
            //{

            //}
            //if (bankName == "Planters Bank")
            //{

            //}
            //if (bankName == "PhilTrust")
            //{

            //}
            //if (bankName == "Philippine Savings Bank")
            //{

            //}
            //if (bankName == "Philippine Savings Bank")
            //{

            //}
            //if (bankName == "Philippine National Bank")
            //{

            //}
            //if (bankName == "Philippine Bank of Communications")
            //{

            //}
            //if (bankName == "Metropolitan Bank And Trust Company")
            //{

            //}
            //if (bankName == "Maybank Philippines")
            //{

            //}
            //if (bankName == "Malayan Bank")
            //{

            //}
            //if (bankName == "Equicom Savings Bank")
            //{

            //}
            //if (bankName == "East West Bank")
            //{

            //}
            //if (bankName == "Citystate Savings Bank")
            //{

            //}
            //if (bankName == "Chinabank Savings")
            //{

            //}
            //if (bankName == "China Banking Corporation")
            //{

            //}
            //if (bankName == "BPI Family Savings Bank")
            //{

            //}
            //if (bankName == "Bank One")
            //{

            //}
            //if (bankName == "Bank of the Philippine Island")
            //{

            //}
            //if (bankName == "Bank of Florida")
            //{

            //}
            //if (bankName == "Bank of Commerce")
            //{

            //}
            //if (bankName == "Banco De Oro")
            //{

            //}
            //if (bankName == "Asia United Bank")
            //{

            //}

        //}


    }
}
