using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickectBookingMVCProject.Models
{
    public class LoginModel
    {
        string gmail, password;
        [Required(ErrorMessage = "Gmail address cannot be empty*")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]

        public string Gmail { get => gmail; set => gmail = value; }
        [Required(ErrorMessage = "Password cannot be empty*")]
        public string Password { get => password; set => password = value; }
    }
}