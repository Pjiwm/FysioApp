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
        public void Update(Patient patient);
        public void Delete(Patient patient);
        public int Count();


    }
}
