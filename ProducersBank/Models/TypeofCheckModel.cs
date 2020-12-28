using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProducersBank.Models
{
    class TypeofCheckModel
    {
        public List<OrderModel> Regular_Personal { get; set; }
        public List<OrderModel> Regular_Commercial { get; set; }
    }
}
