using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickectBookingMVCProject.Models
{
    public class PassangerModel
    {
        int passangercount;
        string pa_name, ps_age, proof;
        SelectList proofs;
        Proofsenum pe;
        string gender;
        public enum Proofsenum
        {
            Adharcard = 1,
            Pancard = 2,

        }
        [Required(ErrorMessage = "Passenger name is required!!!")]
        public string Pa_name { get => pa_name; set => pa_name = value; }
        [Required(ErrorMessage = "Passenger age is required!!!")]
        [Range(1, 100, ErrorMessage = "Only positive number allowed")]
        public string Ps_age { get => ps_age; set => ps_age = value; }
        public string Proof { get => proof; set => proof = value; }
        public SelectList Proofs { get => proofs; set => proofs = value; }
        [Required(ErrorMessage = "Passenger count is required!!!")]
        [RegularExpression(@"^\d", ErrorMessage = "DecimalValue and negative value not allowed")]
        [Range(1, 4, ErrorMessage = "More than four Not allowed ")]
        public int Passangercount { get => passangercount; set => passangercount = value; }
        [Required(ErrorMessage = "Passenger Gender is required!!!")]

        public string Gender { get => gender; set => gender = value; }

        public Proofsenum Pe { get => pe; set => pe = value; }
    }
}