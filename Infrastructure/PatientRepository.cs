using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PatientRepository : IPatientRepository {
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
