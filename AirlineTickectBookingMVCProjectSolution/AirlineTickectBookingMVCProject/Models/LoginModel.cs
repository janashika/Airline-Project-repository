using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickectBookingMVCProject.Models
{
    public class LoginModel
    {
        string phoneNumber, password;
        [Required(ErrorMessage = "Phone number cannot be empty*")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Not a valid phone number")]

        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        [Required(ErrorMessage = "Password cannot be empty*")]
        public string Password { get => password; set => password = value; }
    }
}