using System;
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
        public string POorder { get; set; }
        public double DocStampPrice { get; set; }
        public double TotalAmount { get; set; }
        public double unitprice { get; set; }

    }
}
