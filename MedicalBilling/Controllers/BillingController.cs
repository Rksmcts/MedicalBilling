using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalBilling.ViewModel;

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
        /*
        public ActionResult GenerateInvoice()
        {
            return View();
        }
        */
        [HttpPost]
        public ActionResult GenerateInvoice(BillingViewModel m)
        {
            return View();
        }

        public ActionResult GenerateInvoice(int id)
        {
            Invoice mdl = db.Invoices.Find(id);
            return View("GenerateInvoice", mdl);
        }


        public ActionResult GenerateNewInvoice()
        {
            ViewBag.Customers = db.Customers.ToList();
            return View();
        }
    
        [HttpPost]
        public ActionResult GenerateNewInvoice(Invoice mdl)
        {
            int? invoiceId = db.Invoice_IdMax().First();
            mdl.id = (int)invoiceId+1;
            mdl.date = DateTime.Now;
            mdl.uid = 1;
            mdl.status = 11;
            db.Invoices.Add(mdl);
            db.SaveChanges();
            return View("GenerateInvoice",mdl);
        }


        public ActionResult GetCurrentItem(int id)
        {
            Invoice i = new Invoice();
            i.InvoiceItems = db.InvoiceItems.Where(x => x.invoiceId == id).ToList();
            return PartialView("_InvoiceCurrentItem",i);
        }
        public ActionResult ViewInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewInvoice(BillingViewModel m)
        {
            return View();
        }
    }
}