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

namespace ProducersBank.Services
{
    class ProcessServices
    {
       // MySqlConnection con = new MySqlConnection();
        public MySqlConnection myConnect;
        public string databaseName = "";
        string Sql = "";
        public void DBConnect()
        {
            try
            {
                string DBConnection = "";
               
                //   if (frmLogIn.userName == "elmer")
                //  {
                 DBConnection = "datasource=localhost;port=3306;username=root;password=corpcaptive; convert zero datetime=True;";

                databaseName = "captive_accounting";
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
                    MySqlCommand cmd = new MySqlCommand(Sql, myConnect);
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
            MySqlCommand cmd = new MySqlCommand(Sql, myConnect);
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
        //public List<TempModel> SearchBatch(List<TempModel> _orders )
        //{
        //    Sql = "SELECT DRNumber, PackNumber, BRSTN, ChkType, BranchName, COUNT(BRSTN)," +
        //        "MIN(StartingSerial), MAX(EndingSerial),ChequeName, Batch FROM " + databaseName + ".producers_history WHERE  Batch = '" + _batch + "'" +
        //         "GROUP BY DRNumber, BRSTN, ChkType, BranchName,ChequeName ,Batch ORDER BY DRNumber, PackNumber;";
        //    MySqlCommand cmd = new MySqlCommand(Sql, myConnect);
        //    MySqlDataReader myReader = cmd.ExecuteReader();
        //    while (myReader.Read())
        //    {
        //        TempModel order = new TempModel();
        //        order.DrNumber = myReader.GetString(0);
        //        order.PackNumber = myReader.GetString(1);
        //        order.BRSTN = myReader.GetString(2);
        //        order.ChkType = myReader.GetString(3);
        //        order.BranchName = myReader.GetString(4);
        //        order.Qty = myReader.GetInt32(5);
        //        order.StartingSerial = myReader.GetString(6);
        //        order.EndingSerial = myReader.GetString(7);
        //        order.ChequeName = myReader.GetString(8);
        //        order.Batch = myReader.GetString(9);

        //        list.Add(order);
        //    }
        //    DBClosed();


        //    return _orders;
        //}
    }
}
