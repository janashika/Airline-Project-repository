using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineTickectBookingMVCProject.Models;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.ComponentModel;
using System.Threading;
using System.Text;


namespace AirlineTickectBookingMVCProject.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SendMailToUser()
        {
            bool Result = false;
            Result = SendEmail("deillabi@gmail.com", "send confirmation", "<p> hi deril </p>");
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail =System.Configuration.ConfigurationManager.AppSettings["senderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["senderPassword"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }


    }
}