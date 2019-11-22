using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineTickectBookingMVCProject.Models;
using User_Reg_BL_Library;
using SearchFlightModelLibrary;

namespace AirlineTickectBookingMVCProject.Controllers
{
    [HandleError]
    public class FlightSearchController : Controller
    {
        RegBL bl = new RegBL();
        public ActionResult Search()
        {
            FlightSearchResult places = new FlightSearchResult();
            List<string> s_myList = bl.FetchPlaceNames();
            List<string> d_myList = bl.FetchPlaceNames();
            places.BoardingFrom = new SelectList(s_myList);
            places.LandingIn = new SelectList(d_myList);
            if (ModelState.IsValid)
            {
                return View(places);
            }
            else
            {
                return View("Search");
            }

        }
        
        //[ActionName("Animation")]
        [HttpPost]
        public ActionResult Search(FlightSearchResult fg)
        {

            // return fg.FlightDate.ToShortDateString()+ " "+fg.Boarding+" "+fg.Landing+""+fg.NoOfPassangers;

            List<FlightChild> flights = new List<FlightChild>();
            FlightChild flight = null;
            String s = fg.FlightDate.ToString();
            TempData["start"] = fg.Boarding;
            TempData.Keep();
            TempData["end"] = fg.Landing;
            TempData.Keep();
            if ((fg.Boarding != null) && (fg.Landing != null))
            {
                try
                {
                    List<SearchFlight> modelFlights = bl.getDetails(fg.FlightDate.ToShortDateString(), fg.Boarding, fg.Landing);

                    if (String.Equals(fg.Boarding, fg.Landing))
                    {
                        ViewBag.Mesage = "Source And destination are same.Please try again ";
                    }
                    foreach (SearchFlight item in modelFlights)
                    {
                        flight = new FlightChild();
                        flight.Flightid = item.Flightid;
                        flight.Departuretime = item.Departuretime;
                        flight.Arrivaltime = item.Arrivaltime;
                        flight.Duration = item.Duration;
                        flight.Fare = item.Fare;
                        flights.Add(flight);
                    }
                }
                catch (NoFlightInDatabaseException noflightException)
                {
                    ViewBag.Message = noflightException.Message;
                }
                catch (Exception exception)
                {
                    ViewBag.Message = exception.Message;
                }
            }
            else
            {
                ViewBag.Message = "Invalid source and destination.Try Again!!!!";
            }
            return View("SearchFlightPage", flights);
        }
        public ActionResult Animation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchFlightPage(FlightChild fl)
        {
            //Session["id"] =fl.Flightid;
            
            return View(fl);

        }
        
        public ActionResult Booking(string id)
        {
           
            int val = Convert.ToInt32(id);
            if(bl.InsertBooking(val))
            {
                return View("Animation");
            }
            else
            {
                return View();
            }
           
        }


       
    }
}