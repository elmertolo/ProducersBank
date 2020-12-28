using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;


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

        }

        public bool OpenDB()
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
                string sql = "select primarykey, batch, chequename, ChkType, deliverydate, count(ChkType) as Quantity from producers_history where salesinvoice is null group by batch, chequename, ChkType";
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
                "and deliverydate = '" + deliveryDate.ToString("yyyy=MM-dd") + "';";

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


    }
}
