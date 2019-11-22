using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;




namespace AirlineTickectBookingMVCProject.Models
{
    public class FlightSearchResult : IComparable<FlightSearchResult>
    {
        string noOfPassangers;
        SelectList boardingFrom;
        SelectList landingIn;
        DateTime flightdate;
        string boarding, landing;
        

        [Required(ErrorMessage = "No of Passenegers cannot be empty")]
        public string NoOfPassangers { get => noOfPassangers; set => noOfPassangers = value; }

        [Required(ErrorMessage = "journey date cannot be empty")]
        public DateTime FlightDate { get => flightdate; set => flightdate = value; }

        [Required(ErrorMessage = "Boarding place cannot be empty")]
        public SelectList BoardingFrom { get => boardingFrom; set => boardingFrom = value; }

        [Required(ErrorMessage = "Destination place cannot be empty")]
        public SelectList LandingIn { get => landingIn; set => landingIn = value; }
        public string Boarding { get => boarding; set => boarding = value; }
        public string Landing { get => landing; set => landing = value; }
        public override bool Equals(object obj)
        {
            if (this.Boarding == ((FlightSearchResult)obj).Boarding)
                return true;
            else
                return false;
        }
        public int CompareTo(FlightSearchResult other)
        {
            return this.Boarding.CompareTo(other.boarding);
        }
    }
}