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
using System.Diagnostics;

namespace ProducersBank.Services
{
    public class ProcessServices_Nelson
    {
        //For Number of Affected Rows upon CRUD
        private int rowNumbersAffected;
        public int RowNumbersAffected
        {
            get { return rowNumbersAffected; }
        }

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

            OpenDB();

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
                string sql = "select batch, chequename, ChkType, deliverydate, count(ChkType) as Quantity from " + gHistoryTable + " where salesinvoice is null group by batch, chequename, ChkType";
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
                "and deliverydate = '" + deliveryDate.ToString("yyyy-MM-dd") + "';";

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

        public bool UpdateTempTable(List<SalesInvoiceModel> SalesInvoiceList)
        {
            try
            {
                foreach (var row in SalesInvoiceList)
                {
                    string sql = "insert into producers_salesinvoice_temp " +
                                 "(Quantity, Batch, CheckName, DRList) values " +
                                 "(" + row.Quantity + "," +
                                 " '" + row.Batch.ToString() + "'," +
                                 " '" + row.checkName.ToString() + "'," +
                                 " '" + row.drList.ToString() + "'" +

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

            //Determine path when running through IDE or not
            string reportPath;
            if (Debugger.IsAttached)
            {
                reportPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\SalesInvoice.rpt";
            }
            else
            {
                reportPath = Directory.GetCurrentDirectory().ToString() + @"\SalesInvoice.rpt";
            }

            if (!File.Exists(reportPath))
            {
                throw (new Exception("Unable to locate report file: \r\n" + reportPath));
            }

            crystalDocument.Load(reportPath);


            crystalDocument.SetDataSource(gReportDT);
            crystalDocument.SetParameterValue("prHeaderReportTitle", gSIheaderReportTitle.ToString() ?? "");
            crystalDocument.SetParameterValue("prHeaderReportAddress1", gSIHeaderReportAddress1.ToString() ?? "");
            crystalDocument.SetParameterValue("prHeaderReportAddress2", gSIHeaderReportAddress2.ToString() ?? "");
            crystalDocument.SetParameterValue("prHeaderReportAddress3", gSIHeaderReportAddress3.ToString() ?? "");
            crystalDocument.SetParameterValue("prHeaderCompanyName", gHeaderReportCompanyName.ToString() ?? "");
            crystalDocument.SetParameterValue("prSalesInvoiceDate", gSalesInvoiceDate.ToString("MMMMM dd, yyyy") ?? "");
            crystalDocument.SetParameterValue("prSalesInvoiceNumber", gSalesInvoiceNumber.ToString() ?? "");
            crystalDocument.SetParameterValue("prPreparedBy", gSalesInvoiceGeneratedBy.ToString() ?? "");
            crystalDocument.SetParameterValue("prCheckedBy", gSalesinvoiceCheckedBy.ToString() ?? "");
            crystalDocument.SetParameterValue("prApprovedBy", gSalesInvoiceApprovedBy.ToString() ?? "");
            crystalDocument.SetParameterValue("prSubtotalAmount", gSalesInvoiceSubtotalAmount.ToString() ?? "");
            crystalDocument.SetParameterValue("prVatAmount", gSalesInvoiceVatAmount.ToString() ?? "");
            crystalDocument.SetParameterValue("prNetOfVatAmount", gSalesInvoiceNetOfVatAmount.ToString() ?? "");
            crystalDocument.SetParameterValue("prCustomerCode", gCustomerCode.ToString() ?? "");

        }

        public double GetUnitPrice(string checkName)
        {

            MySqlCommand cmd = new MySqlCommand("select unitprice as UnitPrice from producers_pricelist where chequename = '" + checkName + "'", con);
            var result = (double)cmd.ExecuteScalar();
            return result;

        }

        public bool UpdateSalesInvoiceHistory(List<SalesInvoiceModel> siListToProcess)
        {

            try
            {
                //database update
                MySqlCommand cmd;
                foreach (var item in siListToProcess)
                {

                    //Update History Table
                    string sql = "update " + gHistoryTable + " set " +
                    "unitprice = " + item.unitPrice + ", " +
                    "SalesInvoice = " + gSalesInvoiceNumber + ", " +
                    "Salesinvoicedate = '" + gSalesInvoiceDate.ToString("yyyy-MM-dd") + "', " +
                    "SalesInvoiceGeneratedBy = '" + gSalesInvoiceGeneratedBy + "' " +
                    " where drnumber in(" + item.drList.ToString() +
                    ") and batch = '" + item.Batch + "'" +
                    " and deliverydate = '" + item.deliveryDate.ToString("yyyy-MM-dd") + "'" +
                    " and chequename = '" + item.checkName + "';";

                    cmd = new MySqlCommand(sql, con);
                    rowNumbersAffected = cmd.ExecuteNonQuery();

                }

                //Insert to SalesInvoice Finished
                string sql2 = "insert into " + gSIFinishedTable + " " +
                "(CustomerCode, SalesInvoiceNumber, salesInvoiceDateTime, GeneratedBy, CheckedBy, ApprovedBy, TotalAmount, VatAmount, NetOfVatAmount) " +
                "Values ('" +
                gCustomerCode + "', " +
                gSalesInvoiceNumber + ", '" +
                gSalesInvoiceDate.ToString("yyyy-MM-dd HH:mm") + "', '" +
                gSalesInvoiceGeneratedBy + "', '" +
                gSalesinvoiceCheckedBy + "', '" +
                gSalesInvoiceApprovedBy + "', " +
                gSalesInvoiceSubtotalAmount + ", " +
                gSalesInvoiceVatAmount + ", " +
                gSalesInvoiceNetOfVatAmount + ");";

                cmd = new MySqlCommand(sql2, con);
                rowNumbersAffected = cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {

                _errorMessage = ex.Message;
                return false;
            }

        }

        public bool BatchSearch(string batchToSearch, ref DataTable dt)
        {
            try
            {
                MySqlDataAdapter da;
                string sql = "select batch, chequename, ChkType, deliverydate, count(ChkType) as Quantity from " + gHistoryTable +
                    " where salesinvoice is null and batch = '" + batchToSearch + "' group by batch, chequename, ChkType;";
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

        public bool GetUserNames(ref DataTable dt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select username from users;", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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

        public bool UserLogin(string userName, string password, ref DataTable dt)
        {
            try
            {
                MySqlDataAdapter da;
                MySqlCommand cmd = new MySqlCommand("select * from users where username = ? and password = ?", con);
                cmd.Parameters.Add(new MySqlParameter("username", userName));
                cmd.Parameters.Add(new MySqlParameter("password", password));
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

        public bool GetBankList(ref DataTable dt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select bankname, description from clients order by bankname;", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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

        public bool SalesInvoiceExist(int salesInvoiceNumber, ref DataTable dt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from " + gSIFinishedTable + " where salesinvoicenumber = " + salesInvoiceNumber + ";", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                return false;
            }

        }

        public bool GetOldSalesInvoiceList(double salesInvoiceNumber, ref DataTable dt)
        {
            try
            {
                string sql =
                    "select count(ChkType) as Quantity, batch, chequename as CheckName, group_concat(distinct(drnumber) separator ', ') as DRList, " +
                    "ChkType, deliverydate, (select unitPrice from producers_pricelist where ChequeName = CheckName) as Unitprice, " +
                    "count(ChkType) * UnitPrice as LineTotalAmount " +
                    "from producers_history " +
                    "where salesinvoice = " + salesInvoiceNumber + " " +
                    "group by batch, CheckName, ChkType order by Batch;";


                //"select batch as BatchName, chequename as CheckName, ChkType, deliverydate, count(ChkType) as Quantity, group_concat(distinct(drnumber) separator ', ') as drList " +
                //    "from " + gHistoryTable + " " +
                //    "where salesinvoice = " + salesInvoiceNumber + " group by batch, CheckName, ChkType order by BatchName";

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


        //public bool SeekReturn(string tableName, string fieldName, Type type)
        //{

        //}

    }
}
