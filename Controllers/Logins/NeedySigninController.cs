using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtectYou.Models;
using System.Data.SqlClient;




namespace ProtectYou.Controllers.Logins
{
    public class NeedySigninController : Controller
    {
        
        SqlConnection dbConn = new SqlConnection(@"Data Source=DESKTOP-7KVCKFN\SQLEXPRESS;Initial Catalog=ProtectYou;Integrated Security=True;MultipleActiveResultSets=True");

        //public  Session { get;  set; }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegistrationModel reg)
        {
            string emailpost = HttpContext.Request.Form["email"];
            string passpost = HttpContext.Request.Form["pass"];
            string status = "fail";
            if (emailpost == "" || emailpost == "")
            {
                ViewBag.Message = "Email and Password are required.";
                return View();
            }
            else
            {
                dbConn.Open();
                //where email = '" +reg.Email+ "', and'" +reg.passwd+ "'
                string qry = "SELECT email,password FROM NeedySignup  ";
                SqlCommand selectCMD = new SqlCommand(qry, dbConn);
                SqlDataAdapter dAdapter = new SqlDataAdapter();
                dAdapter.SelectCommand = selectCMD;
                SqlDataReader reader = dAdapter.SelectCommand.ExecuteReader();
                while (reader.Read())
                {
                    string email = reader["email"].ToString();
                    string pass = reader["password"].ToString();

                    if (emailpost.Equals(email) && passpost.Equals(pass))
                    {
                        status = "Success";
                        //Session["Name"] = reg.Name.ToString();
                        
                    }
                }
                dbConn.Close();
            }


            //If user is valid & present in database, we are redirecting it to Admin Home page.
            if (status == "Success")
            {
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                //If the username and password combination is not present in DB then error message is shown.
                ViewBag.Message = "Wrong Username and password combination! Please try again.";
                return View();
            }

        }

    }
}
