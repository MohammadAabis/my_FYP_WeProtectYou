using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtectYou.Models;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ProtectYou.Controllers.Logins
{
    public class NeedySignupController : Controller
    {
        SqlConnection dbConn = new SqlConnection(@"Data Source=DESKTOP-7KVCKFN\SQLEXPRESS;Initial Catalog=ProtectYou;Integrated Security=True;MultipleActiveResultSets=True");
        SqlDataAdapter dAdapter = new SqlDataAdapter();

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(RegistrationModel reg)
        {
            Regex validate_emailaddress = email_validation();

            string status = "Success";
            string name = HttpContext.Request.Form["name"];
            string email = HttpContext.Request.Form["email"];
            string contact = HttpContext.Request.Form["number"];
            string address = HttpContext.Request.Form["address"];
            string family = HttpContext.Request.Form["familyMember"];
            string pswrd = HttpContext.Request.Form["pass"];
            string cpswrd = HttpContext.Request.Form["re_pass"];
            if (name != "" && email != "" && contact != "" && address !="" && family !="" && pswrd != "")
            {
                try
                {

                    if (validate_emailaddress.IsMatch(email) == false) //pswrd.Length < 8
                    {
                        status = "Please Enter Valid Email Address.";
                    }

                    else
                    {
                        if (contact.Length >= 11 && contact.Length <= 13)
                        {
                            if(address.Length < 15)
                            {
                                status = "Please Enter Correct Address.";
                            }
                            else
                            {
                                if(pswrd.Length < 8)
                                {
                                    status = "Password must be greater than 8.";
                                }
                                else
                                {
                                    if(pswrd != cpswrd)
                                    {
                                        status = "Password and Confirm password does not match.";
                                    }
                                    else
                                    {
                                        status = "";
                                        dbConn.Open();
                                        string qry = "INSERT INTO NeedySignup (name,email,contact,address,familyMember,password) Values('" + name + "', '" + email + "', '" + contact + "', '" + address + "', '" + family + "','" + pswrd + "')";
                                        SqlCommand insertCmd = new SqlCommand(qry, dbConn);
                                        dAdapter.InsertCommand = insertCmd;
                                        dAdapter.InsertCommand.ExecuteNonQuery();

                                        dbConn.Close();

                                       // reg.Name = reg.Email = reg.Contact = reg.Address = reg.FamilyMember = "";
                                       

                                        status = "Data inserted Successfully.";
                                        
                                    }
                                }

                            }
                        }
                        else
                        {
                            status = "Please Enter Correct Phone Number";
                        }

                        
                    }

                }
                catch (Exception e)
                {
                    status = e.Message;
                }
            }
            else
            {
                status = "Form fields should not be empty.";
            }

            return Content(status);
        }

        // Needy Person registration end here

        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
    }
}
