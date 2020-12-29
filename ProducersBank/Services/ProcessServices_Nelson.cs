using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using ProducersBank.Models;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using static ProducersBank.GlobalVariables;
using System.IO;


namespace ProducersBank.Services
{
    public class ProcessServices_Nelson
    {
        private string _errorMessage;
        MySqlConnection con;
        MySqlDataAdapter da;
        public string conStr
        {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        } 

        public string errorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public ProcessServices_Nelson()
        {
            try
            {
                OpenDB();
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
              
            }
        }


        private bool OpenDB()
        {
            try
            {
                con = new MySqlConnection(conStr);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                return false;
            }
        }

        public bool LoadInitialData(ref DataTable dt)
        {


            try
            {
                string sql = "select batch, chequename, ChkType, deliverydate, count(ChkType) as Quantity from producers_history where salesinvoice is null group by batch, chequename, ChkType";
                //string sql = "select count(*) as count from producers_history";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                da = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                return true;
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                return false;
            }
        }

        public string GetDRList(string batch, string checktype, DateTime deliveryDate)
        {
            
            try
            {
                
                DataTable dt = new DataTable();

                string sql = "select group_concat(distinct(drnumber) separator ', ') from producers_history " +
                "WHERE salesinvoice is null " +
                "and batch = '" + batch + "' " +
                "and chktype = '" + checktype + "' " +
                "and deliverydate = '" + deliveryDate.ToString("yyyy/MM/dd") + "';";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                da = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                string drList = dt.Rows[0].Field<string>(0).ToString(); // get concatenated delivery number list 
                return drList is null ? "" : drList; // return concatenated delivery number list if not null

            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                return null;
               
            }
        }


        public bool pUpdateTempTable(List<SalesInvoiceModel> SalesInvoiceList)
        {
            try
            {
                foreach (var row in SalesInvoiceList)
                {
                    string sql = "insert into producers_salesinvoice_temp " +
                                 "(OrderQuantity, BatchName, CheckName, DRList, SalesInvoiceDate) values " +
                                 "(" + row.orderQuantity + "," +
                                 " '" + row.batchName.ToString() + "'," +
                                 " '" + row.checkName.ToString() + "'," +
                                 " '" + row.drList.ToString() + "'," +
                                 " '" + row.salesInvoiceDate.ToString("yyyy-MM-dd") + "'" +
                                 ");";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                //MySqlCommand cmd = new MySqlCommand("delete * from producers_tempdatadr;", con);
                //cmd.ExecuteNonQuery();
                _errorMessage = ex.Message;
                return false;
            }

        }

        public bool GetProcessedSalesInvoiceList(ref DataTable dt)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("select * from producers_tempdatadr", con);
                da = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public void FillCRReportParameters(ref ReportDocument crystalDocument)
        {

            //string reportPath = Directory.GetCurrentDirectory().ToString() + @"\SalesInvoice.rpt" ;
            //Abang lang muna itong path na ito
            string reportPath = @"C:\Users\Bon Bon\source\repos\Producers Bank Main\ProducersBank\ProducersBank\SalesInvoice.rpt";

            if (!File.Exists(reportPath))
            {
                throw (new Exception("Unable to locate report file: \r\n" + reportPath));
            }


            crystalDocument.Load(reportPath);
            crystalDocument.SetDataSource(gReportDT);


            if (gHeaderReportTitle != null)
            {
                crystalDocument.SetParameterValue("prHeaderReportTitle", gHeaderReportTitle);
            }
            if (gHeaderReportAddress1 != null)
            {
                crystalDocument.SetParameterValue("prHeaderReportAddress1", gHeaderReportAddress1);
            }
            if (gHeaderReportAddress2 != null)
            {
                crystalDocument.SetParameterValue("prHeaderReportAddress2", gHeaderReportAddress2);
            }
            if (gHeaderReportAddress3 != null)
            {
                crystalDocument.SetParameterValue("prHeaderReportAddress3", gHeaderReportAddress3);
            }
            if (gHeaderReportCompanyName != null)
            {
                crystalDocument.SetParameterValue("prHeaderCompanyName", gHeaderReportCompanyName);
            }
            if (gSalesInvoiceDate != null)
            {
                crystalDocument.SetParameterValue("prSalesInvoicedate", gSalesInvoiceDate.ToString("MMMMM dd, yyyy"));
            }

        }

        public double GetUnitPrice(string checkName)
        {
            
            MySqlCommand cmd = new MySqlCommand("select unitprice as UnitPrice from producers_pricelist where chequename = '" + checkName + "'", con);
            var result = (double)cmd.ExecuteScalar();
            return result;
           


        }

    }
}
