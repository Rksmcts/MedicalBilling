using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalBilling.ViewModel;
using System.Web.Script.Serialization;

namespace MedicalBilling.Controllers
{
    public class BillingController : Controller
    {
        private BillingEntities db = new BillingEntities();
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }

        //Generate_New_Invoice_START
        public ActionResult GenerateNewInvoice()
        {
            ViewBag.Customers = db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult GenerateNewInvoice(Invoice mdl)
        {
            int? invoiceId = db.Invoice_IdMax().First();
            mdl.id = (int)invoiceId + 1;
            mdl.date = DateTime.Now;
            mdl.uid = 1;
            mdl.status = 11;
            db.Invoices.Add(mdl);
            db.SaveChanges();
            return View("GenerateInvoice", mdl);
        }
        //Generate_New_Invoice_END

        //Generate_Invoice_START
        public ActionResult GenerateInvoice(int id)
        {
            BillingViewModel mdl = new BillingViewModel();
            mdl.Invoice = db.Invoices.Find(id);
            return View("GenerateInvoice", mdl);
        }

        [HttpPost]
        public ActionResult GenerateInvoice(BillingViewModel mdl)
        {
            return View("GenerateInvoice");
        }

        public ActionResult GetCurrentItem(int id)
        {
            BillingViewModel mdl = new BillingViewModel();
            ICollection<InvoiceItem> InvoiceItems= db.InvoiceItems.Where(x => x.invoiceId == id).ToList();
            mdl.InvoiceItems = InvoiceItems;
            //mdl.Invoice.id = id;
            //Invoice i = new Invoice();
            //i.InvoiceItems = db.InvoiceItems.Where(x => x.invoiceId == id).ToList();
            return PartialView("_InvoiceCurrentItem",mdl);
        }

        public ActionResult AddItem(int id)
        {
            BillingViewModel mdl= new BillingViewModel();
            ViewBag.id = id;
            mdl.Products = db.Products.ToList();
            mdl.Inventories = db.Inventories.ToList();
            return PartialView("_InvoiceAddItem",mdl);
        }

        //Generate_Invoice_END

        //Fill_Inventory_START
        public string FillInventory(int id)
        {
            ICollection<Inventory> i = db.Inventories.Where(x => x.pid == id).ToList();
            List<MedicalBilling.Models.Inventory> mdl = new List<MedicalBilling.Models.Inventory>();
            foreach (Inventory inv in i)
            {
                MedicalBilling.Models.Inventory x = new MedicalBilling.Models.Inventory();
                    x.iid = inv.iid;
                    x.pid = inv.pid;
                    x.quantity = inv.quantity;
                    x.exDate = inv.exDate;
                    x.batchNo = inv.batchNo;
                    x.status = inv.status;
                mdl.Add(x);
            }
            var txt= new JavaScriptSerializer().Serialize(mdl);
            return txt;
        }
        //Fill_Inventory_END

        //View_Invoice_START
        public ActionResult ViewInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewInvoice(BillingViewModel m)
        {
            return View();
        }
        //View_Invoice_END
    }
}