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

            //Cashier Details============================
            foreach (DataRow row in dt.Rows)
            {

                gUserName = userName;
                //Main mainFrm = new Main();
                //mainFrm.Show();

                //this.Hide();

                gUserName = row.Field<string>("UserName");
                //gUserFullName = row.Field<string>("Name");
            }

            SupplyBankVariables(cbBankList.Text.ToString());

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

        private void SupplyBankVariables(string bankname)
        {
          //  gCustomerCode = proc.GetBankList();
        }

        private void cbBankList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
