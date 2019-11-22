using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineTickectBookingMVCProject.Models
{
    public class LoadModel
    {

     
            string lnameCompany, fnameCompany, source, destination;
            public string LnameCompany { get => lnameCompany; set => lnameCompany = value; }
            public string FnameCompany { get => fnameCompany; set => fnameCompany = value; }
            public string Source { get => source; set => source = value; }
            public string Destination { get => destination; set => destination = value; }
     
}
}