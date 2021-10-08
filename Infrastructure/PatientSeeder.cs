using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class PatientSeeder
    {

        public static List<Patient> Seed(int patientCount)
        {
            List<Patient> patients = new List<Patient>();
            for (int i = 0; i < patientCount; i++)
            {
                patients.Add(new Patient
                {
                    DateOfBirth = DateTime.Now.AddYears(-40),
                    PatientID = 1000 + i,
                    EMail = $"Test@Number{i}.net",
                    Gender = (i% 2 == 0) ? Gender.Male: Gender.Female,
                    Name = $"Test Patient {i}",
                    PhoneNumber = "0612345678",
                    Role = (i % 3 == 0) ? PatientRole.Student: PatientRole.Employee
                });; 
            }
            return patients;
        }
 
    }
}
