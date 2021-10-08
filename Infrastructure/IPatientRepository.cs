using Domain;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IPatientRepository
    {
        // CRUD
        public void Add(Patient patient);
        public Patient ReadByID(int id);
        // updating existing patient doesn't seem to be mandatory for assignment.
        //public void Update(Patient patient);
        public void Delete(Patient patient);
        public int Count();
        IEnumerable<Patient> GetPatients();
    }
}
