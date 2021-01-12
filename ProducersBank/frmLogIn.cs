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

namespace ProducersBank
{
    public partial class frmLogIn : Form
    {

        ProcessServices_Nelson p = new ProcessServices_Nelson();
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
            DataTable dt = new DataTable();

            if (!p.GetBankList(ref dt))
            {
                MessageBox.Show("Unable to connect to server. \r\n" + p.errorMessage);
                Application.Exit();
            }
            cbBankList.DisplayMember = "description";
            cbBankList.DataSource = dt;

        }

        private void Login(string userName, string password)
        {
            DataTable dt = new DataTable();
            if (!p.UserLogin(userName, password, ref dt))
            {
                MessageBox.Show("Unable to connect to server. \r\n" + p.errorMessage);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User Name or Password is incorrect. Please try again");
            }
            else
            {
                Main mainFrm = new Main();
                mainFrm.Show();
                this.Hide();
            }
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

        
    }

}
