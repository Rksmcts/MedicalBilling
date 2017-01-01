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

        public Invoice Invoice { get; set; } = new Invoice();   

        //additional items
        public virtual InvoiceItem InvoiceItem { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        public InvoiceItemWithPrice InvoiceItemWithPrice { get; set; } = new InvoiceItemWithPrice();

        public virtual ICollection<InvoiceItemWithPrice> InvoiceItemsWithPrice { get; set; }

        public InvoicePrint InvoicePrint { get; set; } = new InvoicePrint();
        public int price { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

    }

    public class InvoiceItemWithPrice
    {
        public InvoiceItem InvoiceItem;
        public string product;
        public int batchNo;
        public int quantity;
        public int free;
        public decimal mrp;
        public decimal rate;
        public decimal vat;
        public decimal discount;
        public decimal price;
    }

    public class InvoicePrint
    {
        public string fromName;
        public string fromAddress;
        public string fromPhone;
        public string fromDL_No;
        public string fromTIN_No;
        public string toName;
        public string toAddress;
        public string toPhone;
        public string toDL_No;
        public string toTIN_No;
        public int invoiceNo;
        public string invoiceDate;
        public string invoiceTime;
        public string rep;
        public string dueDate;
        public int userID;
        public List<InvoiceItemWithPrice> items;
        public decimal totalRate;
        public decimal totalVat;
    }

}