using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Reg_BL_Library;
using AirlineTickectBookingMVCProject.Models;

namespace AirlineTickectBookingMVCProject.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HandleError]
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult IndexDOB()
        {
            return View();

        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel register)
        {
            RegBL bl = new RegBL();
            if (ModelState.IsValid)
            {

                if (bl.Insert_userBl(register.FirstName, register.LastName, register.DateOfBirth, register.Nationality, register.Phonenumber, register.Gender, register.Email, register.Password))
                {
                    ViewBag.Message = "its updated";
                    //return View();
                }
            }
            else
            {
                ViewBag.Message = "its not crt";

            }

            return View("Registration");
            //if ((register.FirstName) != " ")
            //{
            //    ViewBag.Message = "Please enter details";
            //}


        }
    }
}