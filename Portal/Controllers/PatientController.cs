using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class PatientController : Controller
    {
        [Authorize(Policy = "RequirePatient")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
