using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IPatientRepository patientRepository;

        public AuthController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return Redirect(loginModel?.ReturnUrl ?? "/Index");
                IdentityUser user = await userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginModel);
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                return Redirect(registerModel?.ReturnUrl ?? "/Index");
                List<Patient> patientResults = patientRepository.ReadAll().Where(p => p.EMail == registerModel.Email).ToList();
                if (await userManager.FindByEmailAsync(registerModel.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email is al gebonden aan een account.");
                }
                else
                {
                    IdentityUser user = new() { UserName = patientResults.First().Name, Email = registerModel.Email };
                    IdentityResult result = await userManager.CreateAsync(user, registerModel.Password);
                    if (result.Succeeded)
                    {
                        Claim claim = new(ClaimTypes.Authentication, "Patient");
                        await userManager.AddClaimAsync(user, claim);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong.");
                    }
                }
            }
            return View(registerModel);
        }


        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}
