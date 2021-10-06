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
        public int PatientId { get; set; }


        //[Required(ErrorMessage = "Please enter your date of birth.")]
        //[DataType(DataType.Date)]
        //public DateTime Age { get; set; }

        //[Required(ErrorMessage = "Please write down a brief description of you symptoms.")]
        //public string Description { get; set; }

        //// diagnose code
        //// medewerker of student
        //// intake gedaan door
        //// optioneel: intake onder supervisie van
        //// hoofdbehandelaar

        //[Required(ErrorMessage = "Please enter the date of registration.")]
        //[DataType(DataType.Date)]
        //public DateTime RegistrationDate { get; set; }

        //// optioneel: datum ontslag behandeling
        //// opmerkingen

        //[Required(ErrorMessage = "Please write down a treatment plan.")]
        //public string TreatmentPlan { get; set; }

        // behandelingen
    }
}
