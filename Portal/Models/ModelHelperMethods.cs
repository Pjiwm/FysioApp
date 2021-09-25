using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public static class ModelHelperMethods
    {
        public static Patient ToDomain(this AddPatientViewModel patient)
        {
            return new Patient
            {
                Name = patient.Name,
                Age = patient.Age,
                Description = patient.Description,
                RegistrationDate = patient.RegistrationDate,
                TreatmentPlan = patient.TreatmentPlan
            };
        }

        public static List<PatientViewModel> ToViewModel(this List<Patient> patients)
        {
            List<PatientViewModel> patientsViewModel = new List<PatientViewModel>();
            foreach (Patient patient in patients)
            {
                patientsViewModel.Add(patient.ToViewModel());
            }
            return patientsViewModel;
        }

        public static PatientViewModel ToViewModel(this Patient patient)
        {
            return new PatientViewModel
            {
                Name = patient.Name,
                Age = patient.Age,
                Description = patient.Description,
                RegistrationDate = patient.RegistrationDate,
                TreatmentPlan = patient.TreatmentPlan
            };
        }
    }
}
