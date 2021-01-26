﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducersBank.Models
{
    class DocStampModel
    {
        public int DocStampNumber { get; set; }
        public string SalesInvoiceNumber { get; set; }
        public string batches { get; set; }
        public DateTime DocStampDate { get; set; }
        public int TotalQuantity { get; set; }
        public string DocDesc { get; set; }
        public string ChkType { get; set; }
        public int POorder { get; set; }
        public int DocStampPrice { get; set; }
        public double TotalAmount { get; set; }
        public double unitprice { get; set; }
        public string BankCode { get; set; }
        public string PreparedBy { get; set; }
        public string CheckedBy { get; set; }
        public int QuantityOnHand { get; set; }

    }
}
