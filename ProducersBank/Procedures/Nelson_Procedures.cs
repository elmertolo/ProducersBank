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

        public static bool ValidateInputFields(string salesInvoiceNumber, string preparedBy, string checkedBy, string approvedBy)
        {
            if (salesInvoiceNumber == "" || preparedBy == "" || checkedBy == "" || approvedBy == "")
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

    }
}
