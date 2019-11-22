using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickectBookingMVCProject.Models
{
    public class RegistrationModel
    {
           string FirstName1, LastName1, Nationality1, Email1, Phonenumber1, gender, Password1;
            //DateTime DateOfBirth;

            [Required(ErrorMessage = "First Name cannot be Empty")]
            public string FirstName { get => FirstName1; set => FirstName1 = value; }

            [Required(ErrorMessage = "Last Name cannot be Empty")]
            public string LastName { get => LastName1; set => LastName1 = value; }


            public string Nationality { get => Nationality1; set => Nationality1 = value; }

            [Required(ErrorMessage = "Email cannot be Empty")]
            [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
            public string Email { get => Email1; set => Email1 = value; }


            [Required(ErrorMessage = "Phone num cannot be Empty")]
            // [MaxLength(10)]
            [RegularExpression(@"[0-9]{10}", ErrorMessage = "Not a valid Phone number")]

            public string Phonenumber { get => Phonenumber1; set => Phonenumber1 = value; }

            [Required(ErrorMessage = "Gender cannot be Empty")]
            public string Gender { get => gender; set => gender = value; }

            [Required(ErrorMessage = "Date of Birth cannot be Empty")]
            //[Range(1, 100, ErrorMessage = "Age must be between 1-100 in years.")]
            // public string DateOfBirth { get => DateOfBirth1; set => DateOfBirth1 = value; }
            [Display(Name = "Date Of Birth")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
         [DateValidation(ErrorMessage = "Sorry, the date can't be later than today's date")]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "password cannot be Empty")]
            public string Password { get => Password1; set => Password1 = value; }
            //public string EmpName { get; set; }
            //[Required]
            //[Display(Name = "Date Of Birth")]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
            //public DateTime DOB { get; set; }
    }
}