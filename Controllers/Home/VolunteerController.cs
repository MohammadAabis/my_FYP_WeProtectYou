﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtectYou.Controllers.Home
{
    public class VolunteerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
