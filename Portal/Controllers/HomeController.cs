using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientRepository _patientRepository;

        public HomeController(ILogger<HomeController> logger, IPatientRepository patientRepository)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }

        public IActionResult Index()
        {
            return View(_patientRepository.Patients.ToViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PatientForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PatientForm(AddPatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                _patientRepository.Patients.Add(patient.ToDomain());
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
