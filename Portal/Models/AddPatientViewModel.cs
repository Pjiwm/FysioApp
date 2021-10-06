using Domain;
using Portal.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class AddPatientViewModel
    {
        [Required(ErrorMessage = "Please Enter the patient's name.")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please Enter the patient's Email address.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Please Enter the patient's patient ID.")]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth.")]
        [Age(16, ErrorMessage = "Patient must be 16 years or older.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public PatientRole Role { get; set; }

    }
}
