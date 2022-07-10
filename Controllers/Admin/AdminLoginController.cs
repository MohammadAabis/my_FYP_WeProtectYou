using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtectYou.Models;

namespace ProtectYou.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        
        //string status = "fail";

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        public string adminName = "admin";
        public string adminPassword = "admin";

        [HttpPost]
        public IActionResult Login(RegistrationModel reg)
        {
            string name = HttpContext.Request.Form["email"];
            string pass = HttpContext.Request.Form["pass"];

            if (name == "" && pass == "")
            {
                ViewBag.Message = "Email and Password are required.";
                return View();
            }
            else
            {
                if (name == adminName && pass == adminPassword)
                {
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    ViewBag.Message = "Wrong Username or Password! Please try again.";
                    return View();
                }
            }
        }
    }
}
