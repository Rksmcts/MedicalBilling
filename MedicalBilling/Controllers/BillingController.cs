using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult View()
        {
            return View();
        }
    }
}