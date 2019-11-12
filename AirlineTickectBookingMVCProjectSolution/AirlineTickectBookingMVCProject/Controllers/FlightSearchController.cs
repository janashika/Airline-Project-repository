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
    public class FlightSearchController : Controller
    {
        public ActionResult Search()
        {
            FlightSearchResult places = new FlightSearchResult();
            if (ModelState.IsValid)
            {
                List<string> s_myList = new List<string>();
                List<string> d_myList = new List<string>();
                s_myList.Add("Chennai");
                s_myList.Add("Hyderabad");
                s_myList.Add("Goa");
                s_myList.Add("Thiruvananthapuram");
                s_myList.Add("Mumbai");
                s_myList.Add("Bengaluru");
                places.BoardingFrom = new SelectList(s_myList);

                d_myList.Add("Chennai");
                d_myList.Add("Hyderabad");
                d_myList.Add("Goa");
                d_myList.Add("Thiruvananthapuram");
                d_myList.Add("Mumbai");
                d_myList.Add("Bengaluru");
                places.LandingIn = new SelectList(d_myList);

            }
           

            return View(places);
        }
        
        [HttpPost]
        public ActionResult Search(FlightSearchResult fg)
        {
           
            // return fg.FlightDate.ToShortDateString()+ " "+fg.Boarding+" "+fg.Landing+""+fg.NoOfPassangers;
            RegBL bl = new RegBL();
            List<FlightChild> flights = new List<FlightChild>();
            FlightChild flight = null;

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
            return View("SearchFlightPage", flights);
        }
        [HttpGet]
        public ActionResult SearchFlightPage(FlightChild fl)
        {
           //List<FlightChild> flights = fl;
            return View(fl);
        }

        //private List<FlightChild> GetAllUserFromBL(FlightSearchResult fl)
        //{
        //    RegBL bl = new RegBL();
        //    List<FlightChild> flights = new List<FlightChild>();
        //    FlightChild flight = null;
        //    List<SearchFlight> modelUsers = bl.getDetails("02-11-2019", fl.Boarding,fl.Landing);
        //    flight = new FlightChild();
        //    foreach (SearchFlight item in modelUsers)
        //    {

        //        flight.Flightid = item.Flightid;
        //        flight.Departuretime = item.Departuretime;
        //        flight.Arrivaltime = item.Arrivaltime;
        //        flight.Duration = item.Duration;
        //        flight.Fare = item.Fare;
        //        flights.Add(flight);
        //    }
        //    return flights;

        //}

    }
}