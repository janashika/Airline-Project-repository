using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineTickectBookingMVCProject.Models;
using User_Reg_BL_Library;

namespace AirlineTickectBookingMVCProject.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginOrSignup()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            RegBL bl = new RegBL();
            if (ModelState.IsValid)
            {
                try
                {
                    if (bl.Login(login.Gmail, login.Password))
                    {
                        // ViewBag.Message = " Invalid phone password right";
                        return RedirectToAction("Search", "FlightSearch");
                        //View("Search", "FlightSearch");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid gmail address or password";
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Message ="Invalid username and password !!!please try again";
                }
               
            }


            return View();
        }


    }
}
