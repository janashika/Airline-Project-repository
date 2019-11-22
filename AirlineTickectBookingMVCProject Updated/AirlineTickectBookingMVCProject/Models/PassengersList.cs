using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineTickectBookingMVCProject.Models
{
    public class PassengersList
    {
        static List<PassangerModel> passangers;
        public PassengersList()
        {
            Passangers = new List<PassangerModel>();
        }

        public List<PassangerModel> Passangers { get => passangers; set => passangers = value; }
    }
}
