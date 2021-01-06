using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducersBank.Models
{
    public class SalesInvoiceModel
    {
        public string batchName { get; set; }
        public double salesInvoiceNumber { get; set; }
        public int orderQuantity { get; set; }
        public double lineTotalAmount { get; set; }
        public string checkName { get; set; }
        public string drList { get; set; }
        public DateTime salesInvoiceDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string checkType { get; set; }
        public double unitPrice { get; set; }
        public string preparedBy { get; set; }
        public string checkedBy { get; set; }
        public string approvedBy { get; set; }
    }
}
