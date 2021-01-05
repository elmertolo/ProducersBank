﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProducersBank.Models;

namespace ProducersBank.Procedures
{
    public static class p
    {
        public static string errorMessage;

        public static bool IsKeyPressedNumeric(ref object sender , ref KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') || ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))) 
            {
                
                return true;
            }
            return false;

        }

        public static bool ValidateInputFields(string salesInvoiceNumber, string preparedBy, string checkedBy, string approvedBy)
        {
            if (salesInvoiceNumber == "" || preparedBy == "" || checkedBy == "" || approvedBy == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static bool UpdateSalesInvoiceFields(List<SalesInvoiceModel> siList)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

    }
}
