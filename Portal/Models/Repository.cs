using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Repository
    {
                private static List<AddPatientViewModel> patients = new List<AddPatientViewModel>();
        public static IEnumerable<AddPatientViewModel> Patients => patients;

        public static void AddPatient(AddPatientViewModel newPatient)
        {
            patients.Add(newPatient);
        }
    }
}
