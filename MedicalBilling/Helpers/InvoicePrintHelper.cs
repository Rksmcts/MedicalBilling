using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalBilling.ViewModel;

namespace MedicalBilling.Helpers
{
    public class InvoicePrintHelper
    {
        private BillingEntities db = new BillingEntities();
        public BillingViewModel getData(int id)
        {
            Invoice inv = db.Invoices.Find(id);
            Customer c = db.Customers.Find(inv.cid);
            User u = db.Users.Find(inv.uid);
            BillingViewModel mdl = new BillingViewModel();
            ICollection<InvoiceItem> InvoiceItems = db.InvoiceItems.Where(x => x.invoiceId == id).ToList();
            List<InvoiceItemWithPrice> InvoiceItemWithPrice = new List<InvoiceItemWithPrice>();
            foreach (InvoiceItem i in InvoiceItems)
            {
                InvoiceItemWithPrice item = new InvoiceItemWithPrice();
                item.InvoiceItem = i;
                item.mrp = (decimal)db.Products.Where(x => x.pid == i.pid).Select(x => x.mrp).First();
                item.vat = (decimal)db.Products.Where(x => x.pid == i.pid).Select(x => x.vat).First();
                item.discount = (decimal)db.Products.Where(x => x.pid == i.pid).Select(x => x.discount).First();
                item.rate = (decimal)db.Products.Where(x => x.pid == i.pid).Select(x => x.rate).First();
                decimal afterVat = (decimal)item.rate + (((item.vat / 100)) * item.rate);
                decimal afterDiscount = (decimal)(afterVat - ((item.rate) * (item.discount / 100)));
                //decimal quantity = (decimal)(item.InvoiceItem.quantity - item.InvoiceItem.free);
                item.price = Math.Round(afterDiscount* (decimal)item.InvoiceItem.quantity, 2);
                //DateTime exDate= (DateTime)db.Inventories.Where(x => x.iid == i.iid).Select(x => x.exDate).First();
                //item.InvoiceItem.Inventory.exDate = exDate.Date;
                InvoiceItemWithPrice.Add(item);
            }
            mdl.InvoicePrint.fromName="KAMAKSHI DISTRIBUTORS";
            mdl.InvoicePrint.fromAddress="Old No.154/3 / New No.43/3, Nehru Road, Kammanahalli, St Thomas Town, Banglaore-560084";
            mdl.InvoicePrint.fromPhone="";
            mdl.InvoicePrint.fromDL_No="KA-B52-150687/150688";
            mdl.InvoicePrint.fromTIN_No="29420383707";
            mdl.InvoicePrint.toName=c.fname+" "+c.mname+" "+c.lname;
            mdl.InvoicePrint.toAddress=c.address;
            mdl.InvoicePrint.toPhone=c.phone;
            mdl.InvoicePrint.toDL_No=c.dlNo;
            mdl.InvoicePrint.toTIN_No=c.tinNo;
            mdl.InvoicePrint.invoiceNo=id;
            mdl.InvoicePrint.invoiceDate = inv.date.ToString("dd/MM/yyyy");
            mdl.InvoicePrint.invoiceTime = inv.date.ToShortTimeString();
            mdl.InvoicePrint.rep=u.name;
            mdl.InvoicePrint.dueDate = inv.dueDate.ToString("dd/MM/yyyy");
            mdl.InvoicePrint.userID=u.uid;
            mdl.InvoicePrint.items=InvoiceItemWithPrice;
            mdl.InvoicePrint.totalRate = 0;
            mdl.InvoicePrint.totalVat = 0;
            InvoiceItemWithPrice.ForEach(i=> { mdl.InvoicePrint.totalRate += (decimal) (i.rate*(i.InvoiceItem.quantity));}); //-i.InvoiceItem.free
            InvoiceItemWithPrice.ForEach(i => { mdl.InvoicePrint.totalVat += Math.Round((decimal)(i.rate * i.vat* (i.InvoiceItem.quantity)) /100, 2); });// - i.InvoiceItem.free
            return mdl;
        }
    }
}