﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using ProducersBank.Services;
using MySql.Data.MySqlClient;

namespace ProducersBank
{
    public partial class ViewReports : Form
    {
        
        public ViewReports()
        {
            InitializeComponent();
        }
        ProcessServices process = new ProcessServices();
        
        //private void crystalReportViewer1_Load(object sender, EventArgs e)
        //{

        //}

        private void ViewReports_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (RecentBatch.report == "DR")
            {
                DataSet ds = new DataSet();
                process.DBConnect();
                string sql = "Select * from producers_tempdatadr ORDER BY BranchName";
                MySqlDataAdapter adp = new MySqlDataAdapter(sql, process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
               
                this.crystalReportViewer1.ReportSource = cryRpt;
                this.crystalReportViewer1.RefreshReport();
                 
            }
            else if (RecentBatch.report == "STICKER" || DeliveryReport.report == "STICKER")
            {
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from producers_sticker ", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
           
                this.crystalReportViewer1.ReportSource =cryRpt;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (RecentBatch.report == "DOC" || DeliveryReport.report == "DOC")
            {
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from docstamp_temp ", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
                this.crystalReportViewer1.ReportSource = cryRpt;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (RecentBatch.report == "Packing" || DeliveryReport.report == "Packing")
            {
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from producers_tempdatadr", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
                this.crystalReportViewer1.ReportSource = cryRpt;
                this.crystalReportViewer1.RefreshReport();
            }
            else if (RecentBatch.report == "SalesInvoice")
            {
                //Commented for because I am having an error upon testing NA_01192021
                //SalesInvoice crystalReport = new SalesInvoice();
                //this.crystalReportViewer1.ReportSource = crystalReport;
                //this.crystalReportViewer1.RefreshReport();
            }
            else if (DeliveryReport.report == "DR")
            {
                DataSet ds = new DataSet();
                process.DBConnect();

                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from producers_tempdatadr", process.myConnect);

                adp.Fill(ds);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(process.FillCRReportParameters());
                cryRpt.SetDataSource(ds.Tables[0]);
                process.DBClosed();
              //  DeliveryReceipt crystalReport = new DeliveryReceipt();
                this.crystalReportViewer1.ReportSource = cryRpt;
                this.crystalReportViewer1.RefreshReport();
            }


        }

        private void crystalReportViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
         //   if ((e.Key == Key.P) && (Keyboard.IsKeyDown(Key.LeftCtrl) ||
         //Keyboard.IsKeyDown(Key.RightCtrl)))
         //       reportViewer.PrintDialog();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if ((e.KeyCode == Keys.P) && (e.KeyCode == Keys.Control))
               crystalReportViewer1.PrintReport();
        }
    }
}
