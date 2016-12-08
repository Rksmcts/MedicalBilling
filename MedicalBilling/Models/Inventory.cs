using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBilling.Models
{
    public class Inventory
    {
        public int iid { get; set; }
        public Nullable<int> pid { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> exDate { get; set; }
        public string batchNo { get; set; }
        public Nullable<int> status { get; set; }
    }
}