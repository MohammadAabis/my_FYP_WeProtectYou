using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using ProtectYou.Models;
using System.Net.Http;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ProtectYou.Controllers
{
    public class ImageProcessingController : Controller
    {
        byte[] _barray1;
        byte[] _barray2;

       
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
        

        //[Route("api/FileAPI/UploadFiles")]
        [HttpPost]
        public IActionResult Index(RegistrationModel reg)
        {
            
            string FilePath = Path.GetTempPath() + Request.Form.Files[0].FileName;
            FileStream fstream = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            ViewBag.image = Request.Form.Files[0].FileName;
            //ViewBag.image = httpRequest.Form.Files.Count;


            return View();
        }

        
    }
}
