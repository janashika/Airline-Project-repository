using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline_Reg_DAL_Library;
using SearchFlightModelLibrary;
using PreviewModelLibrary;

namespace User_Reg_BL_Library
{
    public class RegBL
    {
        RegDAL dal;
        public RegBL()
        {
            dal = new RegDAL();
        }
        public bool Insert_userBl(string ufname, string ulname, DateTime dob, string nat, string pnum, string gender, string gmail, string password)
        {
            return dal.Insert_user(ufname, ulname, dob, nat, pnum, gender, gmail, password);
        }

        public bool Login(string gmail, string password)
        {
            bool loginStatus = false;
            string databasePassword = dal.FetchPassword(gmail);
            if (databasePassword == password)
                loginStatus = true;
            return loginStatus;
        }
        public List<SearchFlight> getDetails(string fldate,string source,string des)
        {
            return dal.GetFlightDetails(fldate,source,des);
        }

        public bool Insert_Passenger(string ps_name, string ps_age, string ps_gender)
        {
            return dal.Add_Passanger(ps_name, ps_age, ps_gender);
        }

        public List<string> FetchPlaceNames()
        {
            return dal.FetchCityName();
        }
        public List<PreviewDetailsModel> PrintPreviewDetails()
        {
            return dal.GetPreviewDetails();
        }
        public bool InsertBooking(int bookingId)
        {
            return dal.insert_Booking(bookingId);
        }
    }
}


