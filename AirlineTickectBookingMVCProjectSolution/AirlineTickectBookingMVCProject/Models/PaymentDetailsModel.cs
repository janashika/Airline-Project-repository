using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickectBookingMVCProject.Models
{
    public class PaymentDetailsModel
    {
        string cardholdername, creditcardnumber, expmonth, expyear, cvv;




        //[Required(ErrorMessage = "Cardholdername cannot be empty")]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage = "Invalid name or variable length")]
        public string CardHolderName { get => cardholdername; set => cardholdername = value; }


        [Required(ErrorMessage = "Only numbers are accepted")]
        [RegularExpression(@"[0-9]{13,16}", ErrorMessage = "Invalid number")]


        public string CreditCardNumber { get => creditcardnumber; set => creditcardnumber = value; }


        [Required(ErrorMessage = "Expmonth cannot be empty")]
        public string ExpMonth { get => expmonth; set => expmonth = value; }

        [Required(ErrorMessage = "Expyear cannot be empty")]
        public string ExpYear { get => expyear; set => expyear = value; }


        //[Required(ErrorMessage = "CVV number cannot be empty")]
        [RegularExpression(@"[0-9]{3}", ErrorMessage = "Invalid cvv number")]
        public string Cvv { get => cvv; set => cvv = value; }


    }
}