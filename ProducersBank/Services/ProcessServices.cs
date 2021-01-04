﻿using System;
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
        public List<OrderModel> Process(List<OrderModel> _orders, DeliveryReport _main, int DrNumber, int packNumber)
        {
            TypeofCheckModel checkType = new TypeofCheckModel();
            //int counter = 0;
            checkType.Regular_Personal = new List<OrderModel>();
            checkType.Regular_Commercial = new List<OrderModel>();


            foreach (OrderModel _check in _orders)
            {

             
                if (_check.ChkType == "A")
                {
                    checkType.Regular_Personal.Add(_check);
                  

                }
                if (_check.ChkType == "B")
                {
                    checkType.Regular_Commercial.Add(_check);
                       
                   
                }
            }
            
            Generate(checkType, DrNumber, _main.deliveryDate, "ELMER", packNumber);
           // Generate(checkType, DrNumber, _main.deliveryDate, "ELMER", packNumber);

            return _orders;
        }
        public void Generate(TypeofCheckModel _checks,int _DrNumber,DateTime _deliveryDate,string _username, int _packNumber)
        {
            DBConnect();
            int counter = 0;

            if (_checks.Regular_Personal.Count > 0)
            {
                //counter++;
                //_checks.Regular_Personal.ForEach(r =>
                //{
                var _list = _checks.Regular_Personal.Select(r => r.BRSTN).Distinct().ToList();
                foreach (string Brstn in _list)
                {
                    var _model = _checks.Regular_Personal.Where(t => t.BRSTN == Brstn);

                    foreach (var r in _model)
                    {


                        Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial," +
                                "DRNumber,DeliveryDate,username,batch,PackNumber )"
                              + "VALUES('" + r.BRSTN + "','" + r.BranchName + "','" + r.AccountNo + "','" + r.AccountNoWithHypen + "','" + r.Name1 + "','" + r.Name2 +
                              "','" + r.ChkType + "','" + r.ChequeName + "','" + r.StartingSerial + "','" + r.EndingSerial + "','" + _DrNumber + "','" + _deliveryDate.ToString("yyyy-MM-dd")
                              + "','" + _username + "','" + r.Batch.TrimEnd() + "','" + _packNumber + "');";
                        cmd = new MySqlCommand(Sql, myConnect);
                        cmd.ExecuteNonQuery();
                    }
                    counter++;
                    if (counter == 10)
                    {
                        _DrNumber++;
                        counter = 0;
                    }


                }

            }
            counter = 0;
            if (_checks.Regular_Commercial.Count > 0)
            {
                var _List = _checks.Regular_Commercial.Select(r => r.BRSTN).Distinct().ToList();
                //if(counter == 0)
                //{
                //    //counter = 0;
                //    _DrNumber++;
                //}
                
                foreach (string Brstn in _List)
                {
                    var _model = _checks.Regular_Commercial.Where(a => a.BRSTN == Brstn);

                    foreach (var r in _model)
                    {


                        Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial," +
                                "DRNumber,DeliveryDate,username,batch,PackNumber )"
                              + "VALUES('" + r.BRSTN + "','" + r.BranchName + "','" + r.AccountNo + "','" + r.AccountNoWithHypen + "','" + r.Name1 + "','" + r.Name2 +
                              "','" + r.ChkType + "','" + r.ChequeName + "','" + r.StartingSerial + "','" + r.EndingSerial + "','" + _DrNumber + "','" + _deliveryDate.ToString("yyyy-MM-dd")
                              + "','" + _username + "','" + r.Batch.TrimEnd() + "','" + _packNumber + "');";
                        cmd = new MySqlCommand(Sql, myConnect);
                        cmd.ExecuteNonQuery();
                        
                        //});
                    }
                    counter++;
                    if (counter == 10)
                    {
                        _DrNumber++;
                        counter = 0;
                    }
                }
            }
            DBClosed();
            return;
        }
        public void GenerateData(List<OrderModel> _orderList, int _DrNumber, DateTime _deliveryDate, string _username, int _packNumber)
        {
            DBConnect();

                var listofBRSTN = _orderList.Select(e => e.BRSTN).Distinct().ToList();
                    
            //var LChkType = _orderList.Select(e => e.ChkType).Distinct().ToList();

            //Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial," +
            //               "DRNumber,DeliveryDate,username,batch,PackNumber )"
            //             + "VALUES('" + _orderList.BRSTN + "','" + _orderList.BranchName + "','" + _orderList.AccountNo + "','" + _orderList.AccountNoWithHypen + "','" + _orderList.Name1 + "','" + _orderList.Name2 +
            //             "','" + _orderList.ChkType + "','" + _orderList.ChequeName + "','" + _orderList.StartingSerial + "','" + _orderList.EndingSerial + "','" + _DrNumber + "','" + _deliveryDate.ToString("yyyy-MM-dd")
            //             + "','" + _username + "','" + _orderList.Batch.TrimEnd() + "','" + _packNumber + "');";
            //cmd = new MySqlCommand(Sql, myConnect);
            //cmd.ExecuteNonQuery();
            int counter = 0;
            foreach (string brstn in listofBRSTN)
            {
               
                var _list = _orderList.Where(r => r.BRSTN == brstn && r.ChkType == "A");
                //_list.OrderBy(a => a.ChkType);
                foreach (var check in _list)
                {
                    Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial,DRNumber,DeliveryDate,username,batch,PackNumber )"
                   + "VALUES('" + check.BRSTN + "','" + check.BranchName + "','" + check.AccountNo + "','" + check.AccountNoWithHypen + "','" + check.Name1 + "','" + check.Name2 +
                   "','" + check.ChkType + "','" + check.ChequeName + "','" + check.StartingSerial + "','" + check.EndingSerial + "','" + _DrNumber + "','" + _deliveryDate.ToString("yyyy-MM-dd") + "','" + _username + "','" + check.Batch.TrimEnd() + "','" + _packNumber + "');";
                    cmd = new MySqlCommand(Sql, myConnect);
                    cmd.ExecuteNonQuery();


                }
               
                //./  var ChkCount= _p
                //if (_list.Count() != _orderList.Where(s => s.ChkType == "A").Count())
                //{
                    counter++;
                    if (counter == 10)
                    {
                        _DrNumber++;
                        counter = 0;
                    }
                //}
                //else
                //{
                //    _DrNumber++;
                //    counter = 0;
                //}

            }
            DBClosed();
            counter = 0;
            
            foreach (var brstn in listofBRSTN)
            {
                _DrNumber = GetLastDRFromHistory();
                if (counter == 0)
                  {
                    _DrNumber++;
                  }

                var _listb = _orderList.Where(r => r.BRSTN == brstn && r.ChkType == "B");
                //_list.OrderBy(a => a.ChkType);
                DBConnect();
                foreach (var check in _listb)
                {
                    Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial,DRNumber,DeliveryDate,username,batch,PackNumber )"
                   + "VALUES('" + check.BRSTN + "','" + check.BranchName + "','" + check.AccountNo + "','" + check.AccountNoWithHypen + "','" + check.Name1 + "','" + check.Name2 +
                   "','" + check.ChkType + "','" + check.ChequeName + "','" + check.StartingSerial + "','" + check.EndingSerial + "','" + _DrNumber + "','" + _deliveryDate.ToString("yyyy-MM-dd") + "','" + _username + "','" + check.Batch.TrimEnd() + "','" + _packNumber + "');";
                    cmd = new MySqlCommand(Sql, myConnect);
                    cmd.ExecuteNonQuery();

                    
                }

                //}
                //if (_orderList.Regular_Commercial.Count > 0)
                //{
                //    _orderList.Regular_Commercial.ForEach(r =>
                //    {
                //        Sql = "Insert into " + databaseName + ".producers_history (BRSTN,BranchName,AccountNo,AcctNoWithHyphen,"
                //            + "Name1,Name2,ChkType,ChequeName,StartingSerial,EndingSerial,DRNumber,DeliveryDate,username,batch,PackNumber )"
                //             + "VALUES('" + r.BRSTN + "','" + r.BranchName + "','" + r.AccountNo + "','" + r.AccountNoWithHypen + "','" + r.Name1 + "','" + r.Name2 +
                //             "','" + r.ChkType + "','" + r.ChequeName + "','" + r.StartingSerial + "','" + r.EndingSerial + "','" + _DrNumber + "','"
                //             + _deliveryDate.ToString("yyyy-MM-dd") + "','" + _username + "','" + r.Batch.TrimEnd() + "','" + _packNumber + "');";
                //        cmd = new MySqlCommand(Sql, myConnect);
                //        cmd.ExecuteNonQuery();
                //    });




                //}

                //if (_listb.Count() != _orderList.Where(s => s.ChkType == "B").Count())
                //{
                    counter++;
                    if (counter == 10)
                    {
                      //  _DrNumber++;
                        counter = 0;
                    }
                //}
               // else
                //{
                //    _DrNumber++;
                //    counter = 0;
                //}
            }

            DBClosed();
            return;
            
        }
        public int GetLastDRFromHistory()
        {
            int LdrNumber = 0;
            Sql = "Select Max(DrNumber) from producers_history";
            DBConnect();
            cmd = new MySqlCommand(Sql, myConnect);
            MySqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {

                LdrNumber = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0;
            }
            reader.Close();
            DBClosed();

            return LdrNumber;
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
            try
            {
                Sql = "SELECT BranchName, BRSTN, ChkType,MIN(StartingSerial), MAX(EndingSerial), Count(ChkType) " +
                      "FROM producers_history WHERE Batch = '" + _batch + "'" +
                       "GROUP BY BranchName, BRSTN, ChkType, ChequeName ORDER BY BranchName";
                DBConnect();
                cmd = new MySqlCommand(Sql, myConnect);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    TempModel t = new TempModel
                    {

                        BranchName = !myReader.IsDBNull(0) ? myReader.GetString(0) : "",
                        BRSTN = !myReader.IsDBNull(1) ? myReader.GetString(1) : "",
                        ChkType = !myReader.IsDBNull(2) ? myReader.GetString(2) : "",
                        StartingSerial = !myReader.IsDBNull(3) ? myReader.GetString(3) : "",
                        EndingSerial = !myReader.IsDBNull(4) ? myReader.GetString(4) : "",
                        Qty = !myReader.IsDBNull(5) ? myReader.GetInt32(5) : 0,
                        //ChequeName = !myReader.IsDBNull(6) ? myReader.GetString(6): ""


                    };
                    _temp.Add(t);
                }
                DBClosed();
                DBConnect();
                string sqldel = "Delete from producers_sticker;";
                MySqlCommand comdel = new MySqlCommand(sqldel, myConnect);
                comdel.ExecuteNonQuery();

                DBClosed();
                DBConnect();

               // int dataCount = 0;
                string Type = "";
                int licnt = 1;
               
                for (int r = 0; r < _temp.Count; r++)
                {

                    if(licnt == 1)
                    {
                        string sql2 = "Insert into producers_sticker (Batch,BRSTN,BranchName,Qty,ChkType,ChequeName,StartingSerial,EndingSerial)" +
                                      "values('" + _batch + "','" + _temp[r].BRSTN + "','" + _temp[r].BranchName + "'," + _temp[r].Qty + ",'" + _temp[r].ChkType +
                                      "','" + Type + "','" + _temp[r].StartingSerial + "','" + _temp[r].EndingSerial + "');";


                        MySqlCommand cmd2 = new MySqlCommand(sql2, myConnect);
                        cmd2.ExecuteNonQuery();
                        licnt++;
                    }
                    else if (licnt == 2)
                    {
                        string sql2 = "Update producers_sticker set BRSTN2 = '" + _temp[r].BRSTN + "',BranchName2 = '" + _temp[r].BranchName + "',Qty2 = " + _temp[r].Qty +
                                      ",ChkType2 = '" + _temp[r].ChkType + "',ChequeName2 = '" + Type + "',StartingSerial2 = '" + _temp[r].StartingSerial +
                                      "',EndingSerial2 = '" + _temp[r].EndingSerial + "' where BRSTN = '" + _temp[r - 1].BRSTN + "';";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, myConnect);
                        cmd2.ExecuteNonQuery();
                        licnt++;
                    }
                    else if (licnt == 3)
                    {
                        string sql2 = "Update producers_sticker set BRSTN3 = '" + _temp[r].BRSTN + "',BranchName3 = '" + _temp[r].BranchName + "',Qty3 = " + _temp[r].Qty +
                                      ",ChkType3 = '" + _temp[r].ChkType + "',ChequeName3 = '" + Type + "',StartingSerial3 = '" + _temp[r].StartingSerial +
                                      "',EndingSerial3 = '" + _temp[r].EndingSerial + "' where BRSTN2 = '" + _temp[r - 1].BRSTN + "';";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, myConnect);
                        cmd2.ExecuteNonQuery();
                        licnt = 1;
                    }

                }
                //for (int z = 0; z < _temp.Count; z++)
                //{

                //    if (licnt == 3)
                //    {
                //        //if ((z % 3) == 0)
                //        //{

                //        if (_temp[z + dataCount].ChkType == "A")
                //            Type = "PERSONAL";
                //        else
                //            Type = "COMMERCIAL";

                //        string sql2 = "Insert into producers_sticker (Batch,BRSTN,BranchName,Qty,ChkType,ChequeName,StartingSerial,EndingSerial,BRSTN2,"
                //               + "BranchName2,Qty2,ChkType2,ChequeName2,StartingSerial2,EndingSerial2,BRSTN3,BranchName3,Qty3,ChkType3,ChequeName3,StartingSerial3,EndingSerial3)"
                //               + "Values('" + _temp[z].Batch + "','" + _temp[z].BRSTN + "','" + _temp[z].BranchName + "'," + _temp[z].Qty
                //               + ",'" + _temp[z].ChkType + "'," + "'" + Type + "','" + _temp[z].StartingSerial + "','" + _temp[z].EndingSerial
                //               + "','" + _temp[z + 1].BRSTN + "','" + _temp[z + 1].BranchName + "'," + _temp[z + 1].Qty + ",'" + _temp[z + 1].ChkType + "','" + Type
                //               + "','" + _temp[z + 1].StartingSerial + "','" + _temp[z + 1].EndingSerial + "','" + _temp[z + 2].BRSTN + "','" + _temp[z + 2].BranchName + "',"
                //               + _temp[z + 2].Qty + ",'" + _temp[z + 2].ChkType + "','" + Type + "','" + _temp[z + 2].StartingSerial + "','" + _temp[z + 2].EndingSerial + "');";


                //        MySqlCommand cmd2 = new MySqlCommand(sql2, myConnect);
                //        cmd2.ExecuteNonQuery();


                //        if (licnt == 3) licnt = 1;
                //    }
                //    else
                //    {
                //        licnt++;

                //        //if (z == _temp.Count)
                //        //{
                //        //    string sql2 = "Insert into producers_sticker (Batch,BRSTN,BranchName,Qty,ChkType,ChequeName,StartingSerial,EndingSerial,BRSTN2,"
                //        //       + "BranchName2,Qty2,ChkType2,ChequeName2,StartingSerial2,EndingSerial2,BRSTN3,BranchName3,Qty3,ChkType3,ChequeName3,StartingSerial3,EndingSerial3)"
                //        //       + "Values('" + _temp[z].Batch + "','" + _temp[z].BRSTN + "','" + _temp[z].BranchName + "'," + _temp[z].Qty
                //        //       + ",'" + _temp[z].ChkType + "'," + "'" + Type + "','" + _temp[z].StartingSerial + "','" + _temp[z].EndingSerial
                //        //       + "','" + _temp[z + 1].BRSTN + "','" + _temp[z + 1].BranchName + "'," + _temp[z + 1].Qty + ",'" + _temp[z + 1].ChkType + "','" + Type
                //        //       + "','" + _temp[z + 1].StartingSerial + "','" + _temp[z + 1].EndingSerial + "','" + _temp[z + 2].BRSTN + "','" + _temp[z + 2].BranchName + "',"
                //        //       + _temp[z + 2].Qty + ",'" + _temp[z + 2].ChkType + "','" + Type + "','" + _temp[z + 2].StartingSerial + "','" + _temp[z + 2].EndingSerial + "');";
                //        //    MySqlCommand cmd2 = new MySqlCommand(sql2, myConnect);
                //        //    cmd2.ExecuteNonQuery();
                //        //}
                //    }


                //}

                DBClosed();
            }
            catch(Exception e)
            {

            }
            return _temp;
        }
      
        //public List<TempModel> GetPackingReport(List<TempModel>  _temp, string _batch)
        //{
        //    Sql = "SELECT BranchName, BRSTN, ChkType,MIN(StartingSerial), MAX(EndingSerial), Count(ChkType) " +
        //              "FROM producers_history WHERE Batch = '" + _batch + "'" +
        //               "GROUP BY BranchName, BRSTN, ChkType, ChequeName ORDER BY BranchName";
        //    DBConnect();
        //    cmd = new MySqlCommand(Sql, myConnect);
        //    MySqlDataReader reader = cmd.ExecuteReader();

        //    while(reader.Read())
        //    {
        //        TempModel t = new TempModel
        //        {
        //            BranchName = !reader.IsDBNull(0) ? reader.GetString(0) : "",
        //            BRSTN = !reader.IsDBNull(1) ? reader.GetString(1) : "",
        //            ChkType = !reader.IsDBNull(2) ? reader.GetString(2) : "",
        //            StartingSerial = !reader.IsDBNull(3) ? reader.GetString(3) : "",
        //            EndingSerial = !reader.IsDBNull(4) ? reader.GetString(4) : "",
        //            Qty = !reader.IsDBNull(5) ? reader.GetInt32(5) : 0
        //        };
        //        _temp.Add(t);
        //    }
        //    reader.Close();
        //    DBClosed();
        //    return _temp;
        //}
    }
}
