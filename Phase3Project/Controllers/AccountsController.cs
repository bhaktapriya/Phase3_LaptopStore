using Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AccountsController : Controller
    {
        UserManager<IdentityUser> _userManager = null;
        SignInManager<IdentityUser> _signInManager = null;
        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser>signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            //ViewBag.msg = "Registered Successfully!!";
            return RedirectToAction("Customer");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //ViewBag.msg = "Login Successfully!!";
            return RedirectToAction("Laptops");
        }
    }
}
