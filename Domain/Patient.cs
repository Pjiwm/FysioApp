using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Patient
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string EMail { get; set; }

        [Key]
        public int PatientID { get; set; }

        //public DateTime Age { get; set; }

        //public string Description { get; set; }

        //// diagnose code
        //// medewerker of student
        //// intake gedaan door
        //// optioneel: intake onder supervisie van
        //// hoofdbehandelaar

        //public DateTime RegistrationDate { get; set; }

        //// optioneel: datum ontslag behandeling
        //// opmerkingen

        //public string TreatmentPlan { get; set; }

        //// behandelingen
    }
}
