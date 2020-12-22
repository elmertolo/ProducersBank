using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProducersBank.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using AxShockwaveFlashObjects;
using System.Collections.Concurrent;
using System.Net.Http.Headers;
using System.IO;
using System.Configuration;

namespace ProducersBank.Services
{
    class ProcessServices
    {
       // MySqlConnection con = new MySqlConnection();
        public MySqlConnection myConnect;
        public string databaseName = "";
        List<string> db = new List<string>();
        List<Int64> listofDR = new List<long>();
        MySqlCommand cmd;
        string Sql = "";
        public void DBConnect()
        {
            try
            {
                string DBConnection = "";

                //   if (frmLogIn.userName == "elmer")
                //  {
                DBConnection = ConfigurationManager.AppSettings["ConnectionString"];

                //databaseName = "captive_accounting";
                //  MessageBox.Show(databaseName);
                //   }
                //else
                //{
                //    //  DBConnection = "";
              //  DBConnection = "datasource=192.168.0.254;port=3306;username=root;password=CorpCaptive; convert zero datetime=True;";
                // MessageBox.Show("HELLO");
              //  databaseName = "captive_accounting";
                //    // MessageBox.Show(databaseName);

                //}

                myConnect = new MySqlConnection(DBConnection);

                myConnect.Open();

            }
            catch (Exception Error)
            {

                MessageBox.Show(Error.Message, "System Error");
            }
        }// end of function

        public void DBClosed()
        {
            myConnect.Close();
        }
        // end of function

        public List<OrderModel> GenerateData(List<OrderModel> _orderList, int _DrNumber,DateTime _deliveryDate,string _username,int _packNumber)
        {
            DBConnect();
         
            var listofBRSTN = _orderList.Select(e => e.BRSTN).Distinct().ToList();
            
            int counter = 0;
            
            foreach (string brstn in listofBRSTN)
            {
    
                var _list = _orderList.Where(r => r.BRSTN == brstn);
                foreach (var check in _list)
                {
                    Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial,DRNumber,DeliveryDate,username,batch,PackNumber )"
                   + "VALUES('" + check.BRSTN + "','" + check.BranchName + "','" + check.AccountNo + "','" + check.AccountNoWithHypen + "','" + check.Name1 + "','" + check.Name2 +
                   "','" + check.ChkType + "','" + check.ChequeName + "','" + check.StartingSerial + "','" + check.EndingSerial + "','" + _DrNumber + "','" + _deliveryDate.ToString("yyyy-MM-dd") + "','" + _username + "','" + check.Batch.TrimEnd() + "','" + _packNumber + "');";
                     cmd = new MySqlCommand(Sql, myConnect);
                    cmd.ExecuteNonQuery();
                }

                counter++;
                if(counter == 10)
                {
                    _DrNumber++;
                    counter = 0;
                }
            }

            DBClosed();
            return _orderList;
            
        }
        public string GetDRDetails(string _batch, List<TempModel> list )
        {
            
            DBConnect();
            Sql = "SELECT DRNumber, PackNumber, BRSTN, ChkType, BranchName, COUNT(BRSTN),"+ 
            "MIN(StartingSerial), MAX(EndingSerial),ChequeName, Batch FROM "+databaseName+".producers_history WHERE  Batch = '"+_batch+"'"+
             "GROUP BY DRNumber, BRSTN, ChkType, BranchName,ChequeName ,Batch ORDER BY DRNumber, PackNumber;";
             cmd = new MySqlCommand(Sql, myConnect);
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                TempModel order = new TempModel();
                order.DrNumber = myReader.GetString(0);
                order.PackNumber = myReader.GetString(1);
                order.BRSTN = myReader.GetString(2);
                order.ChkType = myReader.GetString(3);
                order.BranchName = myReader.GetString(4);
                order.Qty = myReader.GetInt32(5);
                order.StartingSerial = myReader.GetString(6);
                order.EndingSerial = myReader.GetString(7);
                order.ChequeName = myReader.GetString(8);
                order.Batch = myReader.GetString(9);

                list.Add(order);
            }
            DBClosed();
            DBConnect();
            string sqldel = "Delete from  "+databaseName +".producers_tempdatadr;";
            MySqlCommand comdel = new MySqlCommand(sqldel, myConnect);
            comdel.ExecuteNonQuery();

            DBClosed();
            DBConnect();
            for (int i = 0; i < list.Count; i++)
            {


                string sql2 = "Insert into "+databaseName+".producers_tempdatadr (DRNumber,PackNumber,BRSTN, ChkType, BranchName,Qty,StartingSerial,EndingSerial,ChequeName,Batch)" +
                                " Values('" + list[i].DrNumber + "','" + list[i].PackNumber + "','" + list[i].BRSTN + "','" + list[i].ChkType + "','" + list[i].BranchName + "'," + list[i].Qty
                                +",'"+list[i].StartingSerial +"','"+list[i].EndingSerial +"','"+list[i].ChequeName+"','"+list[i].Batch+"');";
            MySqlCommand cmd2 = new MySqlCommand(sql2, myConnect);
                cmd2.ExecuteNonQuery();
            }
            DBClosed();
            return _batch;
        }
      public void GetBankTables()
      {
        //    int counter = 0;
         
            Sql = "Select Distinct(DatabaseName) from captive_accounting.Clients";
            DBConnect();
             cmd = new MySqlCommand(Sql, myConnect);
            MySqlDataReader myReader = cmd.ExecuteReader();
            
            while(myReader.Read())
            {
                string data;
                data = myReader.GetString(0);


                db.Add(data);
              
            }
        
            
            DBClosed();
            //return _DrNumber; 
      }

        public List<Int64> GetMaxDr(List<Int64> _Dr)
        {
             GetBankTables(); 
          
            DBConnect();
            Int64 dr = 0;
            foreach (var item in db)
            {



                Sql = "Select Max(DrNumber) from captive_accounting." + item;
                cmd = new MySqlCommand(Sql, myConnect);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    dr = !read.IsDBNull(0) ?  read.GetInt64(0): 0;

                   _Dr.Add(dr);
                }

                read.Close();
            }    
            DBClosed();


            return _Dr;
        }
        private void  InsertToMaxTB()
        {
            Int64 _drNumber = 0;
           string _salesInvoice = "",  _docStamp= "";
            string Sql2;
            GetBankTables();
            DBConnect();
            
            foreach (var item in db)
            {


                 Sql2 = "Select Max(DrNumber) , Max(SalesInvoice), Max(DocStamp) from " +item.TrimEnd() ;
                MySqlCommand cmd2 = new MySqlCommand(Sql2, myConnect);
                MySqlDataReader reader = cmd2.ExecuteReader();
               
                while (reader.Read())
                {
                    _drNumber =!reader.IsDBNull(0) ? reader.GetInt64(0): 0;
                    _salesInvoice = !reader.IsDBNull(1) ? reader.GetString(1): "";
                    _docStamp = !reader.IsDBNull(2) ?  reader.GetString(2): "";
                }

               
                reader.Close();
                Sql = "Insert into MaxTb (DrNumber,SalesInvoice,Docstamp)values('" + _drNumber.ToString() + "','" + _salesInvoice + "','" + _docStamp + "');";
                cmd = new MySqlCommand(Sql, myConnect);
                cmd.ExecuteNonQuery();

            }


            DBClosed();
          //  return _drNumber;
        }
        public List<Int32> GetMaxPackNumber()
        {
            GetBankTables();
            //InsertToMaxTB();
            DBConnect();
           List<Int32> pack = new List<Int32>();
            Int32 dr = 0;
            foreach (var item in db)
            {


                Sql = "Select Max(PackNumber) from captive_accounting." + item;

               cmd = new MySqlCommand(Sql, myConnect);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    dr = !read.IsDBNull(0) ? read.GetInt32(0): 0;
                    pack.Add(dr);
                }

                read.Close();
            }

            DBClosed();


            return pack;
        }
        
        public List<TempModel> GetStickerDetails(List<TempModel> _temp,string _batch)
        {
            Sql = "SELECT BranchName, BRSTN, ChkType,MIN(StartingSerial), MAX(EndingSerial), Count(ChkType), ChequeName "+
                  "FROM producers_history WHERE Batch = '" + _batch + "'"+
                   "GROUP BY BranchName, BRSTN, ChkType, ChequeName ORDER BY BranchName";

            cmd = new MySqlCommand(Sql, myConnect);
            MySqlDataReader myReader = cmd.ExecuteReader();
            while(myReader.Read())
            {
                TempModel t = new TempModel {

                    BranchName = !myReader.IsDBNull(0) ? myReader.GetString(0) : "",
                    BRSTN = !myReader.IsDBNull(1) ? myReader.GetString(1) : "",
                    ChkType = !myReader.IsDBNull(2) ? myReader.GetString(2):"",
                    StartingSerial = !myReader.IsDBNull(3) ? myReader.GetString(3): "",
                    EndingSerial  = !myReader.IsDBNull(4) ? myReader.GetString(4):"",
                    Qty = !myReader.IsDBNull(5) ? myReader.GetInt32(5):0,
                    ChequeName = !myReader.IsDBNull(6) ? myReader.GetString(6): ""

                    
                };
                _temp.Add(t);
            }
            DBClosed();
            return _temp;
        }
    }
}
