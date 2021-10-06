using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Patient
    {

        [Key]
        [Required]
        public int PatientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }

    }
}
