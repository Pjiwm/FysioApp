using Domain;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IPatientRepository
    {
        public List<Patient> Patients { get; set; }
    }
}
