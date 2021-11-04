using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class AddAppointmentViewModel
    {
        [Required(ErrorMessage = "Please Enter the patient's name.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Please Enter the therapist's name who'll be treating the patient.")]
        public string TherapistName { get; set; }

        [Required(ErrorMessage = "Please enter a valid date and time.")]
        public DateTime AppointmentTime { get; set; }
    }
}
