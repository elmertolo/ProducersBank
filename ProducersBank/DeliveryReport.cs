using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProducersBank.Models;
using ProducersBank.Services;
using CrystalDecisions.Shared;


namespace ProducersBank
{
    public partial class DeliveryReport : Form
    {

        List<OrderModel> orderList = new List<OrderModel>();
        ProcessServices proc = new ProcessServices();
        List<TempModel> tempDr = new List<TempModel>();
        List<TempModel> tempSticker = new List<TempModel>();
        public DateTime deliveryDate;
        DateTime dateTime;
        List<Int64> DrNumbers = new List<long>();
        List<Int32> PNumbers = new List<Int32>();
        Int32 pNumber = 0;
        Int64 _dr = 0;

        public DeliveryReport()
        {
            InitializeComponent();
            dateTime = dateTimePicker1.MinDate = DateTime.Now; //Disable selection of backdated dates to prevent errors  
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deliveryDate = dateTimePicker1.Value;
            if (deliveryDate == dateTime)
            {
                MessageBox.Show("Please set Delivery Date!");
            }
            else
            {
                proc.GenerateData(orderList, int.Parse(txtDrNumber.Text),deliveryDate,"Elmer",int.Parse(txtPackNumber.Text));

                proc.GetDRDetails(orderList[0].Batch,tempDr);
                proc.GetStickerDetails(tempSticker,orderList[0].Batch);
                //CrystalReport1 cr = new CrystalReport1();
                //cr.Load(Application.StartupPath + "\\DeliveryReceipt.rpt");
         
                MessageBox.Show("Data has been process!!!");
                ViewReports vp = new ViewReports();
               // vp.MdiParent = this;
                vp.Show();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            GetData();

        }
        private void ChequeName()
        {
            comboBox1.Items.Add("Regular Checks");
            comboBox1.Items.Add("Manager's Checks");
            comboBox1.SelectedIndex = 0;
        }
        //private void BankName()
        //{
        //    cmbBank.Items.Add("PRODUCERS BANK");
        //    cmbBank.Items.Add("PNB");
        //    cmbBank.SelectedIndex = 0;
        //}

        private void GetData()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;


            OpenFileDialog op = new OpenFileDialog();
            //op.InitialDirectory = Application.StartupPath;
            op.InitialDirectory = @"\\192.168.10.254\Accounting_Files\Packing\ProducersBank";
            op.Filter = "dbf files (*.dbf)|*.dbf|All files (*.*)|*.*";
            op.FilterIndex = 2;
            op.RestoreDirectory = true;
            if (op.ShowDialog() == DialogResult.OK)
            {
                string ConString = "Provider = VFPOLEDB.1; Data Source = " + op.FileName + ";";
                OleDbConnection con = new OleDbConnection(ConString);



                //Get the path of specified file
                filePath = Path.GetFileNameWithoutExtension(op.FileName);

                //Read the contents of the file into a stream
                var fileStream = op.OpenFile();

                //  DataTable dt = con.GetSchema(OleDbMetaDataCollectionNames.Tables);
                var sql = "Select * FROM " + filePath;
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                OleDbDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    OrderModel order = new OrderModel();
                    order.Batch = myReader.GetString(0);
                    order.BRSTN = myReader.GetString(2);
                    order.BranchName = myReader.GetString(4);
                    order.AccountNo = myReader.GetString(5);
                    order.Name1 = myReader.GetString(8);
                    order.Name2 = myReader.GetString(9);
                    order.ChkType = myReader.GetString(7);
                    order.AccountNoWithHypen = myReader.GetString(6);
                    order.StartingSerial = myReader.GetString(12);
                    order.EndingSerial = myReader.GetString(14);
                    if (order.ChkType == "A" && comboBox1.Text == "Regular Checks")
                        order.ChequeName = "Regular Personal Checks";
                    else
                        order.ChequeName = "Regular Commercial Checks";
                    if (order.ChkType == "A" && comboBox1.Text == "Manager's Checks")
                        order.ChequeName = "Manager's Checks";


                    orderList.Add(order);
                }


            }

            BindingSource checkBind = new BindingSource();
            checkBind.DataSource = orderList;
            dataGridView1.DataSource = checkBind;
        }

       

        private void DeliveryReport_Load(object sender, EventArgs e)
        {
            ChequeName();
            //  BankName();
        
            GetDR();
            GetPack();
         
        }
        private void GetPack()
        {
            PNumbers = proc.GetMaxPackNumber();

            for (int a = 0; a < PNumbers.Count; a++)
            {

                if (pNumber > PNumbers[a])
                {
                    // MessageBox.Show("Lah");
                }
                else
                    pNumber = PNumbers[a];
                    
            }
            txtPackNumber.Text = pNumber.ToString();
        }
        private void GetDR()
        {
            proc.GetMaxDr(DrNumbers);

            // Int64.Parse(txtDrNumber.Text)
            for (int i = 0; i < DrNumbers.Count; i++)
            {
                if (_dr > DrNumbers[i])
                {

                }
                else
                    _dr = DrNumbers[i];
                    
            }
            txtDrNumber.Text = _dr.ToString();
            return;

        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecentBatch rb = new RecentBatch();
            rb.Show();
            this.Hide();
        }

        private void btnDr_Click(object sender, EventArgs e)
        {
            GetDR();
            MessageBox.Show("Generate Delivery Receipt Number done!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
