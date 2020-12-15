﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducersBank.Models
{
    class OrderModel
    {
        public string BRSTN { get; set; }
        public string AccountNo { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Batch { get; set; }
        public string StartingSerial { get; set; }
        public string EndingSerial { get; set; }
        public string BranchName { get; set; }
        public string ChkType { get; set; }
        public string AccountNoWithHypen { get; set; }
        public string ChequeName { get; set; }
    }
}
