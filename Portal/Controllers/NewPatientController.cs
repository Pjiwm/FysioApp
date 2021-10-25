using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class NewPatientController : Controller
    {

        private readonly IPatientRepository patientRepository;
        public NewPatientController(IPatientRepository patients)
        {
            patientRepository = patients;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PatientForm(AddPatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                patientRepository.Add(patient.ToDomain());
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
