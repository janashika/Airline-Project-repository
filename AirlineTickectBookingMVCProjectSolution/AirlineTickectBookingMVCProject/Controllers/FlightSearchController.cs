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
        
        [HttpPost]
        public ActionResult Search(FlightSearchResult fg)
        {
           
            // return fg.FlightDate.ToShortDateString()+ " "+fg.Boarding+" "+fg.Landing+""+fg.NoOfPassangers;
           
            List<FlightChild> flights = new List<FlightChild>();
            FlightChild flight = null;
            //if(String.Equals(fg.Boarding,fg.Landing))
            //{
            //    ViewBag.Mesage = "Source And destination are same.Please try again ";
            //}
            if((fg.Boarding!=null)&&(fg.Landing!=null))
            {
                try
                {
                    List<SearchFlight> modelFlights = bl.getDetails(fg.FlightDate.ToShortDateString(), fg.Boarding, fg.Landing);

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
        [HttpGet]
        public ActionResult SearchFlightPage(FlightChild fl)
        {
            return View(fl);
        }
    }
}