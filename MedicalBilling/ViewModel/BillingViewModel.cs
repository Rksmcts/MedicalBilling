using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBilling.ViewModel
{
    public class BillingViewModel
    {
        //public int id { get; set; }
        //public Nullable<int> cid { get; set; }
        //public Nullable<int> uid { get; set; }
        //public Nullable<System.DateTime> date { get; set; }
        //public Nullable<System.DateTime> dueDate { get; set; }
        //public Nullable<int> status { get; set; }

        //public virtual Customer Customer { get; set; }
        //public virtual Status Status1 { get; set; }
        //public virtual User User { get; set; }
        //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        public Invoice Invoice { get; set; }

        //additional items
        public virtual InvoiceItem InvoiceItem { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}