using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineTickectBookingMVCProject.Models;

namespace AirlineTickectBookingMVCProject.Controllers
{
    [HandleError]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment(PaymentDetailsModel payment)
        {
            if (ModelState.IsValid)
                ViewBag.Message = "right";
            else
                ViewBag.Message = "wrong";
            return View();
        }

    }
}