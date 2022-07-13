using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

namespace ProtectYou.Controllers
{
    public class ImageProcessingController : Controller
    {
        byte[] _barray1;
        byte[] _barray2;
        private object webHostEnvironment;

        public IActionResult Index()
        {
            string FilePath = @"C:\Users\hp\source\repos\ProtectYou\wwwroot\img\about.jpg";
            FileStream fstream = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            using (BinaryReader reader1 = new BinaryReader(fstream))
            {
                _barray1 = reader1.ReadBytes((int)fstream.Length);
            }


            ViewBag.image = _barray1.Length;


            return View();
        }
    }
}
