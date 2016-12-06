using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBilling.ViewModel
{
    public class BillingViewModel
    {
        public int id { get; set; }
        public Nullable<int> cid { get; set; }
        public Nullable<int> uid { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> dueDate { get; set; }
        public Nullable<int> status { get; set; }

        public List<InvoiceItem> invoiceItem { get; set; }
    }
}