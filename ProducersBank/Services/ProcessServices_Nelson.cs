﻿using System;
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

        public bool LoadUnprocessedSalesInvoiceData(ref DataTable dt)
        {
            try
            {
                string sql = "select batch, chequename, ChkType, deliverydate, count(ChkType) as Quantity from " + gClient.DataBaseName + " where salesinvoice is null group by batch, chequename, ChkType";
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


        public bool LoadPriceListData(ref DataTable dt)
        {
            try
            {
                string sql = "select productcode, bankcode, chequeName, description, UnitPrice, Docstamp from " + gClient.PriceListTable + "";
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


        public bool LoadSearchedItem(string inputText ,ref DataTable dt)
        {
            try
            {
                string sql = "select productcode, bankcode, chequeName, description, UnitPrice, Docstamp from " + gClient.PriceListTable + " where chequeName like '%" + inputText + "%';";
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


                string sql = "select group_concat(distinct(drnumber) separator ', ') from " + gClient.DataBaseName + " " +
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
        
        public bool UpdateTempTableSI(List<SalesInvoiceModel> SalesInvoiceList)
        {
            try
            {
                foreach (var row in SalesInvoiceList)
                {
                    string sql = "insert into " + gClient.SalesInvoiceTempTable + " " +
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

        public double GetUnitPrice(string checkName)
        {


            MySqlCommand cmd = new MySqlCommand("select unitprice as UnitPrice from " + gClient.PriceListTable + " where chequename = '" + checkName + "'", con);
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
                    string sql;
                    //PNB Update. Added Purchase Order Field upon updating
                    if (gClient.ShortName == "PNB")
                    {
                        //Update History Table
                         sql = "update " + gClient.DataBaseName + " set " +
                        "unitprice = " + item.unitPrice + ", " +
                        "purchaseordernumber = " + item.PurchaseOrderNumber + ", " +
                        "SalesInvoice = " + gSalesInvoiceFinished.SalesInvoiceNumber + ", " +
                        "Salesinvoicedate = '" + item.salesInvoiceDate.ToString("yyyy-MM-dd") + "', " +
                        "SalesInvoiceGeneratedBy = '" + gSalesInvoiceFinished.GeneratedBy + "' " +
                        " where drnumber in(" + item.drList.ToString() +
                        ") and batch = '" + item.Batch + "'" +
                        " and deliverydate = '" + item.deliveryDate.ToString("yyyy-MM-dd") + "'" +
                        " and chktype = '" + item.checkType.ToString() + "'" +
                        " and chequename = '" + item.checkName + "';";
                    }
                    else
                    {

                        //Update History Table
                        sql = "update " + gClient.DataBaseName + " set " +
                        "unitprice = " + item.unitPrice + ", " +

                        "SalesInvoice = " + gSalesInvoiceFinished.SalesInvoiceNumber + ", " +
                        "Salesinvoicedate = '" + item.salesInvoiceDate.ToString("yyyy-MM-dd") + "', " +
                        "SalesInvoiceGeneratedBy = '" + gSalesInvoiceFinished.GeneratedBy + "' " +

                        " where drnumber in(" + item.drList.ToString() +
                        ") and batch = '" + item.Batch + "'" +
                        " and deliverydate = '" + item.deliveryDate.ToString("yyyy-MM-dd") + "'" +
                        " and chktype = '" + item.checkType.ToString() + "'" +
                        " and chequename = '" + item.checkName + "';";
                    }



                    cmd = new MySqlCommand(sql, con);
                    rowNumbersAffected = cmd.ExecuteNonQuery();

                }

                //Insert to SalesInvoice Finished
                string sql2 = "insert into " + gClient.SalesInvoiceFinishedTable + " " +
                "(ClientCode, SalesInvoiceNumber, salesInvoiceDateTime, GeneratedBy, CheckedBy, ApprovedBy, TotalAmount, VatAmount, NetOfVatAmount) " +
                "Values ('" +
                gSalesInvoiceFinished.ClientCode + "', " +
                gSalesInvoiceFinished.SalesInvoiceNumber + ", '" +
                gSalesInvoiceFinished.SalesInvoiceDateTime.ToString("yyyy-MM-dd HH:mm") + "', '" +
                gSalesInvoiceFinished.GeneratedBy + "', '" +
                gSalesInvoiceFinished.CheckedBy + "', '" +
                gSalesInvoiceFinished.ApprovedBy + "', " +
                gSalesInvoiceFinished.TotalAmount + ", " +
                gSalesInvoiceFinished.VatAmount + ", " +
                gSalesInvoiceFinished.NetOfVatAmount + ");";

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

        public bool UpdatePurchaseOrderFinished(List<PurchaseOrderModel> poListToProcess)
        {

            try
            {
                //database update
                MySqlCommand cmd;
                foreach (var item in poListToProcess)
                {

                    //Insert Purchase Order Finished
                    string sql = "insert into " + gClient.PurchaseOrderFinishedTable + " " +
                    "(purchaseorderno, purchaseorderdatetime, clientcode, productcode, quantity, chequename, description, unitprice, docstamp, generatedby, checkedby, approvedby) " +
                    "Values (@PurchaseOrderNumber, @PurchaseOrderDateTime, @ClientCode, @ProductCode, @Quantity, @ChequeName, @Description, @UnitPrice, @Docstamp, @GeneratedBy, @CheckedBy, @ApprovedBy)";

                    cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.Add("@PurchaseOrderNumber", MySqlDbType.Int32).Value = item.PurchaseOrderNumber;
                    cmd.Parameters.Add("@PurchaseOrderDateTime", MySqlDbType.DateTime).Value = item.PurchaseOrderDateTime;
                    cmd.Parameters.Add("@ClientCode", MySqlDbType.String).Value = item.ClientCode;
                    cmd.Parameters.Add("@ProductCode", MySqlDbType.String).Value = item.ProductCode;
                    cmd.Parameters.Add("@Quantity", MySqlDbType.Int32).Value = item.Quantity;
                    cmd.Parameters.Add("@ChequeName", MySqlDbType.String).Value = item.ChequeName;
                    cmd.Parameters.Add("@Description", MySqlDbType.String).Value = item.Description;
                    cmd.Parameters.Add("@UnitPrice", MySqlDbType.Double).Value = item.UnitPrice;
                    cmd.Parameters.Add("@Docstamp", MySqlDbType.Double).Value = item.Docstamp;
                    cmd.Parameters.Add("@GeneratedBy", MySqlDbType.String).Value = item.GeneratedBy;
                    cmd.Parameters.Add("@CheckedBy", MySqlDbType.String).Value = item.CheckedBy;
                    cmd.Parameters.Add("@ApprovedBy", MySqlDbType.String).Value = item.ApprovedBy;

                    rowNumbersAffected = cmd.ExecuteNonQuery();

                }

                

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
                string sql = "select batch, chequename, ChkType, deliverydate, count(ChkType) as Quantity from " + gClient.DataBaseName +
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
                MySqlCommand cmd = new MySqlCommand("select username, password, firstname, middlename, lastname, suffix, lockout from userlist;", con);
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
                MySqlCommand cmd = new MySqlCommand("select * from userlist where username = ? and password = ?", con);
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
                MySqlCommand cmd = new MySqlCommand("select clientcode, shortname, description, address1, address2, address3, attentionto, Princes_DESC, TIN, WithholdingTaxPercentage, " +
                    "databasename from clientlist order by shortname;", con);
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
                MySqlCommand cmd = new MySqlCommand("select * from " + gClient.SalesInvoiceFinishedTable + " where salesinvoicenumber = " + salesInvoiceNumber + ";", con);
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
                    "ChkType, deliverydate, (select unitPrice from " + gClient.PriceListTable + " where ChequeName = CheckName) as Unitprice, " +
                    "count(ChkType) * UnitPrice as LineTotalAmount " +
                    "from " + gClient.DataBaseName + " " +
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

        public object SeekReturn(string query, string type)

        {
           
            MySqlCommand cmd = new MySqlCommand(query, con);
            var result = cmd.ExecuteScalar();


            //Catch Null Values
            if (type.ToLower() == "string")
            {
                string i;
                i = (string)Convert.ChangeType(result ?? "", typeof(string));
                return i;

            }
            if (type.ToLower() == "double")
            {
                double i;
                i = (double)Convert.ChangeType(result ?? 0, typeof(double));
                return i;

            }
            if (type.ToLower() == "int")
            {
                int i = (int)Convert.ChangeType(result, typeof(int));
                return i;

            }
            if (type.ToLower() == "decimal")
            {
                decimal i = (decimal)Convert.ChangeType(result, typeof(decimal));
                return i;

            }

            return null;



        }

        public bool GetClientDetails(string clientDescription, ref DataTable dt)
        {
            try
            {
                string sql = "select clientcode, shortname, description, address1, address2, address3, attentionto, Princes_DESC, TIN, WithholdingTaxPercentage, " +
                    "databasename from clientlist " +
                    "where description = '" + clientDescription + "' order by shortname;";
                MySqlCommand cmd = new MySqlCommand(sql , con);
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


        //PNB
        public bool IsQuantityOnHandSufficient(double toProcessQuantity, string chequeName, int purchaseOrderNumber, ref double remainingQuantity)
        {
            
            try
            {

                //Check Onhand quantity first. cancel update if onhand quantity is insufficient
                //double onhandQuantity = double.Parse(SeekReturn("select (quantityonhand) from " + gClient.PriceListTable + " where chequename = '" + chequeName + "'").ToString() ?? "");
                //NA_01252021 Revision from above statement. changed target field when checking onhand quantity of chequename
                double onhandQuantity = double.Parse(SeekReturn("select quantity from " + gClient.PurchaseOrderFinishedTable + " where chequename = '" + chequeName + "' and purchaseorderno = " + purchaseOrderNumber + "", "double").ToString());
                double processedQuantity = double.Parse(SeekReturn("select count(chequename) as quantity from " + gClient.DataBaseName + " where chequename = '" + chequeName + "' and purchaseordernumber = " + purchaseOrderNumber + "", "double").ToString());
                remainingQuantity = onhandQuantity - processedQuantity - toProcessQuantity;

                if (remainingQuantity < 0)
                {
                    _errorMessage = "Insufficient " + chequeName + " Quantity.";
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

        //PNB
        public bool UpdateItemQuantityOnhand(double toProcessQuantity, string chequeName, int purchaseOrderNumber)
        {
            try
            {
                //Check Onhand quantity first. cancel update if onhand quantity is insufficient
                //double onhandQuantity = double.Parse(SeekReturn("select quantityonhand from " + gClient.PriceListTable + " where chequename = '" + chequeName + "'").ToString() ?? "");
                //double newItemQuantity = onhandQuantity - quantity;

                double onhandQuantity = double.Parse(SeekReturn("select quantity from " + gClient.PurchaseOrderFinishedTable + " where chequename = '" + chequeName + "' and purchaseorderno = " + purchaseOrderNumber + "", "double").ToString());
                double processedQuantity = double.Parse(SeekReturn("select count(chequename) as quantity from " + gClient.DataBaseName + " where chequename = '" + chequeName + "' and purchaseordernumber = " + purchaseOrderNumber + "", "double").ToString());
                double newItemQuantity = onhandQuantity - processedQuantity;

                MySqlCommand cmd = new MySqlCommand("Update " + gClient.PriceListTable + " set quantityonhand = " + newItemQuantity + " where chequeName = '" + chequeName + "'", con);
                rowNumbersAffected = cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                return false;
            }
        }






    }
}
