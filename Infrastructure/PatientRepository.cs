using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PatientRepository : IPatientRepository {
        private List<Patient> Patients { get; set; }

        public void Add(Patient patient)
        {
            Patients.Add(patient);
        }

        public int Count()
        {
            return Patients.Count;
        }

        public void Delete(Patient patient)
        {
            Patients.Remove(patient);
        }

        public Patient ReadByID(int id)
        {
            return Patients[id];
        }

    }
}
