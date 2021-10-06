using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Employee
    {
        [Required]
        string Name { get; set; }
        [EmailAddress]
        string Email { get; set; }
        Gender Gender { get; set; }
        [Phone]
        string PhoneNumber { get; set; }
        [Key]
        [Required]
        // can either be a student or employee ID
        int ID { get; set; }
        [Required]
        EmployeeRole Role { get; set; }
        // BIG-Number is only for Employees with physical therapist role
        int BIGNumber { get; set; }
    }
}
