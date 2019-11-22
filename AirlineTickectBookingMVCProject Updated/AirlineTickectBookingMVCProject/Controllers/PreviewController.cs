using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineTickectBookingMVCProject.Models;
using User_Reg_BL_Library;
using PreviewModelLibrary;


namespace AirlineTickectBookingMVCProject.Controllers
{
    public class PreviewController : Controller
    {
        //GET: Preview
        public ActionResult DisplayPassengerDetails()
        {
            List<PreviewModel> users = GetUserPreviewDetails();
            try
            {
                
                if (users != null)
                {
                    return View(users);
                }
                else
                {
                    ViewBag.message = "No user Found";
                    return View("DisplayPassengerDetails");
                }
            }
            catch (Exception)
            {
                return View(users);

            } 
            
        }
        private List<PreviewModel> GetUserPreviewDetails()
        {

            RegBL bl = new RegBL();
            List<PreviewModel> users = new List<PreviewModel>();
            PreviewModel user = null;
            List<PreviewDetailsModel> modelUsers = bl.PrintPreviewDetails();
            foreach (PreviewDetailsModel item in modelUsers)
            {
                user = new PreviewModel();

                user.S_Id = item.S_Id;
                user.Des_Id = item.Des_Id;
                user.Departure_Time = item.Departure_Time;
                user.Arrival_Time = item.Arrival_Time;
                user.Passenger = item.Passenger;
                user.Booked_Date = item.Booked_Date;
                user.Fare = item.Fare;

                users.Add(user);
            }
            return users;
        }
    }
}