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
                try
                {
                    if (bl.Insert_userBl(register.FirstName, register.LastName, register.DateOfBirth, register.Nationality, register.Phonenumber, register.Gender, register.Email, register.Password))
                    {
                        ViewBag.Message = string.Format("Registered sucessfully Go Back and Login");
                    }

                    else
                    {
                        ViewBag.Message = "Not registered try again!!!";

                    }
                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("PRIMARY KEY"))
                    {
                        ViewBag.Message = "Mail id Already exists!!! Try Again!!!";
                        return View();
                    }
                    
                }
            }
            return View();
        }
    }
}