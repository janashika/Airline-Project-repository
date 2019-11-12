using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineTickectBookingMVCProject.Models;
using User_Reg_BL_Library;

namespace AirlineTickectBookingMVCProject.Controllers
{
    public class PassengerController : Controller
    {
        // GET: Passenger
        PassengersList passengers = new PassengersList();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            // PassangerModel passenger = new PassangerModel();

            return View();
        }
        [HttpPost]
        public ActionResult Create(PassangerModel passanger)
        {
            TempData["cd"] = passanger.Passangercount;
            if (ModelState.IsValid)
            {
                //TempData["pass"] = passanger.Passangercount;
                //RedirectToAction("addPassenger");

                //return View("addPassenger", passanger);
                //return new RedirectResult("addPassenger");
                //TempData["count"] = passanger.Passangercount;

            }
            return RedirectToAction("addPassenger");


        }

        public ActionResult addPassenger()
        {
            int passangerCount = Convert.ToInt32(TempData["cd"].ToString());
            PassangerModel passenger;
            if (ModelState.IsValid)
            {
                passengers.Passangers = new List<PassangerModel>();

                for (int i = 0; i < passangerCount; i++)
                {
                    passenger = new PassangerModel();
                    passengers.Passangers.Add(passenger);
                }


            }

            return View(passengers);

        }

        [HttpPost]
        public string addPassenger(PassengersList passengersList)
        {
            RegBL bl = new RegBL();
            //List<PassangerModel> pl = passengers;
            foreach (PassangerModel item in passengersList.Passangers)
            {
                if (bl.Insert_Passenger(item.Pa_name, item.Ps_age, item.Gender))
                {
                    ViewBag.message = "passanger details added";
                    // RedirectToAction("addPaddPassenger");
                }
                else
                {
                    ViewBag.message = "not added";
                }
            }

            return ViewBag.message;

        }

    }
}
