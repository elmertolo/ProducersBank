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
using System.Diagnostics;
using System.IO;
using ProducersBank.Services;

namespace ProducersBank.Procedures
{


    public static class p
    {

        public static string message;

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


        public static void FillCRReportParameters(string reportType)
        {

            switch (reportType) 
            {
                case "SalesInvoice":

                    gCrystalDocument.SetDataSource(gReportDT);
                    gCrystalDocument.SetParameterValue("prHeaderReportTitle", gSIheaderReportTitle.ToString() ?? "");
                    //gSalesInvoiceFinished Global model used to supply parameters
                    gCrystalDocument.SetParameterValue("prHeaderReportAddress1", gClient.Address1.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prHeaderReportAddress2", gClient.Address2.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prHeaderReportAddress3", gClient.Address3.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prHeaderCompanyName", gClient.Description.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prSalesInvoiceDate", gSalesInvoiceFinished.SalesInvoiceDateTime.ToString("MMMMM dd, yyyy") ?? "");
                    gCrystalDocument.SetParameterValue("prSalesInvoiceNumber", gSalesInvoiceFinished.SalesInvoiceNumber.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prPreparedBy", gSalesInvoiceFinished.GeneratedBy.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prCheckedBy", gSalesInvoiceFinished.CheckedBy.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prApprovedBy", gSalesInvoiceFinished.ApprovedBy.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prSubtotalAmount", gSalesInvoiceFinished.TotalAmount.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prVatAmount", gSalesInvoiceFinished.VatAmount.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prNetOfVatAmount", gSalesInvoiceFinished.NetOfVatAmount.ToString() ?? "");
                    gCrystalDocument.SetParameterValue("prClientCode", gClient.ClientCode.ToString() ?? "");

                    if (gClient.ShortName == "PNB")
                    {

                    }

                    break;

                default:
                    message = "Report type not recognized.";
                    
                    break;
            
            }

           

        }

        public static bool LoadReportPath(string reportType) 
        {

            string reportPath;

            //Determine path when running through IDE or not
            if (Debugger.IsAttached)
            {
                reportPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Reports\" + gClient.ShortName + "_" + reportType + ".rpt";
            }
            else
            {
                reportPath = Directory.GetCurrentDirectory().ToString() + @"\Reports\" + gClient.ShortName + "_" + reportType + ".rpt";

            }

            if (!File.Exists(reportPath))
            {
                return false;
            }

            gCrystalDocument.Load(reportPath);
            return true;


        }




    }
}
