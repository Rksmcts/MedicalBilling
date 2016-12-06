using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicalBilling;

namespace MedicalBilling.Controllers
{
    public class InvoicesController : Controller
    {
        private BillingEntities db = new BillingEntities();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Customer).Include(i => i.Status1).Include(i => i.User);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.Customers, "cid", "fname");
            ViewBag.status = new SelectList(db.Status, "id", "description");
            ViewBag.uid = new SelectList(db.Users, "uid", "username");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cid,uid,date,dueDate,status")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.Customers, "cid", "fname", invoice.cid);
            ViewBag.status = new SelectList(db.Status, "id", "description", invoice.status);
            ViewBag.uid = new SelectList(db.Users, "uid", "username", invoice.uid);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.Customers, "cid", "fname", invoice.cid);
            ViewBag.status = new SelectList(db.Status, "id", "description", invoice.status);
            ViewBag.uid = new SelectList(db.Users, "uid", "username", invoice.uid);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cid,uid,date,dueDate,status")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.Customers, "cid", "fname", invoice.cid);
            ViewBag.status = new SelectList(db.Status, "id", "description", invoice.status);
            ViewBag.uid = new SelectList(db.Users, "uid", "username", invoice.uid);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
