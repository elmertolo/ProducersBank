using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProducersBank.Procedures;

namespace ProducersBank
{
    public partial class frmMessageInput : Form
    {
        public string labelMessage;
        public string userInput;
        

        public frmMessageInput()
        {
            InitializeComponent();
            txtInput.Focus();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Please input Sales Invoice Number.");
                return;
            }
            userInput = txtInput.Text.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (p.IsKeyPressedNumeric(ref sender, ref e))
            {
                e.Handled = true;
            }
        }
    }
}
