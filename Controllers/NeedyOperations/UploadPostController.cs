using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtectYou.Models;

namespace ProtectYou.Controllers.NeedyOperations
{
    public class UploadPostController : Controller
    {
        public IActionResult UploadPost()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult UploadPost(PostRequirements post)
        {
            
            return View();
        }
    }
}
