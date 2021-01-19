using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProducersBank.Services;
using static ProducersBank.GlobalVariables;
using ProducersBank.Procedures;
using ProducersBank.Models;


namespace ProducersBank
{
    public partial class frmLogIn : Form
    {
        DataTable BankListDT = new DataTable();
        ProcessServices_Nelson proc = new ProcessServices_Nelson();
        public static string tableName = "";
        public static string tempTableName = "";
        public frmLogIn()
        {
            InitializeComponent();
            FillBankList();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Login(txtUserName.Text.ToString(), txtPassword.Text.ToString());

        }

        private void FillBankList()
        {
           
            if (!proc.GetBankList(ref BankListDT))
            {
                MessageBox.Show("Unable to connect to server. \r\n" + proc.errorMessage);
                Application.Exit();
                
            }
            cbBankList.DisplayMember = "description";
            cbBankList.DataSource = BankListDT;

        }

        private void Login(string userName, string password)
        {
            DataTable dt = new DataTable();
            if (!proc.UserLogin(userName, password, ref dt))
            {
                MessageBox.Show("Unable to connect to server. \r\n" + proc.errorMessage);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User Name or Password is incorrect. Please try again");
                return;
            }



            //Load Cashier Details============================
            SupplyGlobalUserVariables(ref dt);

            SupplyGlobalClientVariables(cbBankList.Text.ToString());

            if(cbBankList.Text== "Philippine National Bank")
            {
                tableName = "pnb_history";
                tempTableName = "pnb_temp";
                MessageBox.Show(tableName);
            }
            else if (cbBankList.Text == "Producers Bank")
            {
                tableName = "producers_history";
                MessageBox.Show(tableName);
            }
            Main mainFrm = new Main();
            mainFrm.Show();
            this.Hide();
           
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login(txtUserName.Text.ToString(), txtPassword.Text.ToString());
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login(txtUserName.Text.ToString(), txtPassword.Text.ToString());
            }
            
        }

        private void SupplyGlobalClientVariables(string bankname)
        { 
            DataTable dt = new DataTable();
            if(!proc.GetClientDetails(bankname,ref dt))
            {
                MessageBox.Show("Server Connection Error (GetBankList)\r\n" + proc.errorMessage);
            }


            if (dt.Rows.Count != 0)
            {
                
                foreach (DataRow row in dt.Rows)
                {
                    gClient.ClientCode = row.Field<string>("ClientCode") ?? "";
                    gClient.ShortName = row.Field<string>("ShortName") ?? "";
                    gClient.Description = row.Field<string>("Description") ?? "";
                    gClient.Address1 = row.Field<string>("Address1") ?? "";
                    gClient.Address2 = row.Field<string>("Address2") ?? "";
                    gClient.Address3 = row.Field<string>("Address3") ?? "";
                    gClient.AttentionTo = row.Field<string>("AttentionTo") ?? "";
                    gClient.Princes_DESC = row.Field<string>("Princes_DESC") ?? "";
                    gClient.TIN = row.Field<string>("TIN") ?? "";
                    gClient.WithholdingTaxPercentage = row.Field<decimal>("WithholdingTaxPercentage");
                    gClient.DataBaseName = row.Field<string>("DataBaseName") ?? "";
                    gClient.SalesInvoiceTempTable = row.Field<string>("SalesInvoiceTempTable") ?? "";
                    gClient.SalesInvoiceFinishedTable = row.Field<string>("SalesInvoiceFinishedTable") ?? "";
                    gClient.PriceListTable = row.Field<string>("PriceListTable") ?? "";
                    gClient.DRTempTable = row.Field<string>("DRTempTable") ?? "";
                }
            }
           
            
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {


        }

        public void SupplyGlobalUserVariables(ref DataTable dt) 
        {
           
            foreach (DataRow row in dt.Rows)
            {
                gUser.UserName = row.Field<string>("UserName");
                gUser.Password = row.Field<string>("Password");
                gUser.FirstName = row.Field<string>("FirstName");
                gUser.MiddleName = row.Field<string>("MiddleName");
                gUser.LastName = row.Field<string>("LastName");
                gUser.Suffix = row.Field<string>("Suffix");
                gUser.Lockout = row.Field<string>("Lockout");

            }
        }

       


    }

}
