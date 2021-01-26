using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducersBank.Models
{
    class PriceListModel
    {
        public string Bank { get; set; }
        public string ChequeDescription { get; set; }
        public string ChkType { get; set; }
        public  int DocStampPrice { get; set; }
        public double unitprice{ get; set; }

    }
}
