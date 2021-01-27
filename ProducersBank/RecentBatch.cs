﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using ProducersBank.Models;
using ProducersBank.Services;
using static ProducersBank.GlobalVariables;

namespace ProducersBank
{
    public partial class RecentBatch : Form
    {
        Main frm;
        public static string report = "";
        ProcessServices proc = new ProcessServices();
         List<TempModel> tempRecent = new List<TempModel>();
        List<TempModel> batchTemp = new List<TempModel>();
        List<DocStampModel> docTemp = new List<DocStampModel>();
        public RecentBatch(Main frm1)
        {
            InitializeComponent();
            this.frm = frm1;
        }



        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool flag = true;
            if (txtRecentBatch.Text != "")
            {
                tempRecent.Clear();
                proc.GetDRDetails(txtRecentBatch.Text, tempRecent);
                tempRecent.Clear();
                proc.GetStickerDetails(tempRecent, txtRecentBatch.Text);

                var dBatchtemp = batchTemp.Select(d => d.Batch).Distinct().ToList();

                if (gClient.DataBaseName != "producers_history")
                {
                    foreach (string batch in dBatchtemp)
                    {
                        var _dbatch = batchTemp.Where(r => r.Batch == batch).ToList();
                        _dbatch.ForEach(f =>
                        {
                            if (flag == true)
                            {
                                proc.GetDocStampDetails(docTemp, f.DocStampNumber);
                                flag = false;
                            }

                        });

                    }
                    documentStampToolStripMenuItem.Enabled = true;
                }
                else
                    documentStampToolStripMenuItem.Enabled = false;
                printDRToolStripMenuItem.Enabled = true;
                MessageBox.Show("Batch :" + txtRecentBatch.Text + " has been generated!!!");
            }
            else
                MessageBox.Show("Please enter Batch Number!");
        }

        private void deliveryReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "DR";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        //private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Main m = new Main();
        //    m.Show();
        //}

        private void printDRToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stickersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "STICKER";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void packingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "Packing";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "SalesInvoice";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void RecentBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //Form f = new Main();
            //f.Show();
        }

        private void RecentBatch_Load(object sender, EventArgs e)
        {
            txtRecentBatch.Focus();
        }

        private void txtRecentBatch_TextChanged(object sender, EventArgs e)
        {
            batchTemp.Clear();
            proc.DisplayAllBatches(txtRecentBatch.Text,batchTemp);
            DataTable dt = new DataTable();

            dt.Clear();

            dt.Columns.Add("Batch");
            dt.Columns.Add("Sales Invoice");
            dt.Columns.Add("Document Stamp");
            dt.Columns.Add("Cheque Name");
            dt.Columns.Add("ChkType");
            dt.Columns.Add("Delivery Date");
            dt.Columns.Add("Quantity");
                

            batchTemp.ForEach(r =>
            {
                dt.Rows.Add(new object[] { r.Batch, r.SalesInvoice, r.DocStampNumber,r.ChequeName, r.ChkType, r.DeliveryDate.ToString("yyyy-MM-dd"), r.Qty });
            });
            
            dgvDRList.DataSource = dt;

            dgvDRList.Columns[3].Width = 200;
            dgvDRList.Columns[5].Width = 130;
        }

        private void dgvDRList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowindex = dgvDRList.CurrentCell.RowIndex;
            int columnindex = dgvDRList.CurrentCell.ColumnIndex;

            // student.Stud_ID = int.Parse(dtgList.Rows[rowindex].Cells[columnindex].Value.ToString());
            
            txtRecentBatch.Text = dgvDRList.Rows[rowindex].Cells[columnindex].Value.ToString();
            //if(columnindex == 0)
            //{
            //    lblNote.Text = "This is Batch Number!";
            //}
            //else if (columnindex == 1)
            //{
            //    lblNote.Text = "This is Sales Invoice Number!";
            //}
            //else if( columnindex == 2)
            //lblNote.Text = "This is Document Stamp Number!";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        //    string _batch = txtRecentBatch.Text;    
        //    DialogResult result1 = MessageBox.Show("Are you sure Deleting Batch :" + _batch+"?", "", MessageBoxButtons.YesNo);

        //    if (result1.ToString() == "Yes")
        //    {
        ////    isExist:
        //        ProcessServices.InputBox("", "Batch Number :", ref _batch);
                

        //        proc.DeleteBatch(txtRecentBatch.Text);

        //        MessageBox.Show("Batch has been deleted!");
        //        txtRecentBatch.Text = "";
        //        dgvDRList.Refresh();
        //        batchTemp.Clear();
        //    }
        //    else
        //        MessageBox.Show("Deletion Cancelled!!");
        }

        private void documentStampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report = "DOC";
            ViewReports vp = new ViewReports();
            vp.Show();
        }

        private void txtDrNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
