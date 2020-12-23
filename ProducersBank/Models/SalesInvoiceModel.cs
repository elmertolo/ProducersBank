using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducersBank.Models
{
    public class SalesInvoiceModel
    {
        public string batch { get; set; }
        public string checkName { get; set; }
        public string drList { get; set; }
        public string checkType { get; set; }
        public DateTime deliveryDate { get; set; }
        public int quantity { get; set; }
    }
}
