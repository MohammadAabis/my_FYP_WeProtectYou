using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ProtectYou.Models;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;


namespace ProtectYou.Controllers.Logins
{
    public class ngoSignupController : Controller
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
            string file = Path.GetFileName(reg.Image.ToString());
            ViewBag.Message = file;



            Regex validate_emailaddress = email_validation();

            string status = "Success";
            string name = HttpContext.Request.Form["name"];
            string email = HttpContext.Request.Form["email"];
            string contact = HttpContext.Request.Form["number"];
            string address = HttpContext.Request.Form["address"];
            string regDate = HttpContext.Request.Form["registrationDate"];
            string regNumber = HttpContext.Request.Form["registrationNumber"];
            string regWith = HttpContext.Request.Form["registerWith"];
            double budget = Convert.ToDouble(HttpContext.Request.Form["currentAnnualBudget"]); 
            string img = reg.Image; 
            string pswrd = HttpContext.Request.Form["pass"];
            string cpswrd = HttpContext.Request.Form["re_pass"];

            
            if (name != "" && email != "" && contact != "" && address != "" && regNumber != "" && regWith != "" && budget > 0 && img != "" && pswrd != "")
            {
                try
                {

                    if (validate_emailaddress.IsMatch(email) == false) 
                    {
                        status = "Please Enter Valid Email Address.";
                    }

                    else
                    {
                        if (contact.Length >= 11 && contact.Length <= 13)
                        {
                            if (address.Length < 15)
                            {
                                status = "Please Enter Correct Address.";
                            }
                            else
                            {
                                if (pswrd.Length < 7)
                                {
                                    status = "Password must be greater than 8.";
                                }
                                else
                                {
                                    if (pswrd != cpswrd)
                                    {
                                        status = "Password and Confirm password does not match.";
                                    }
                                    else
                                    {
                                        status = "";                                     
                                        dbConn.Open();
                                        string qry = "INSERT INTO ngoSignup (name,email,phone,address,registrationDate,registrationNumber,registeredWith,currentAnnualBudget,image,pasword) Values(@name, @email, @contact, @address, @regDate, @regNumber, @regWith, @budget, @img, @pswrd)";
                                        //SqlCommand insertCmd = new SqlCommand(qry, dbConn);
                                        
                                        using (var command = new SqlCommand(qry, dbConn))
                                        {
                                            command.Parameters.AddWithValue("@name", name ?? (object)DBNull.Value);
                                            command.Parameters.AddWithValue("@email", email ?? (object)DBNull.Value);
                                            command.Parameters.AddWithValue("@contact", contact ?? (object)DBNull.Value);
                                            command.Parameters.AddWithValue("@address", address);
                                            command.Parameters.AddWithValue("@regDate",  regDate);
                                            command.Parameters.AddWithValue("@regNumber", regNumber);
                                            command.Parameters.AddWithValue("@regWith", regWith);
                                            command.Parameters.AddWithValue("@budget", budget);
                                            command.Parameters.AddWithValue("@img", img ?? (object)DBNull.Value);
                                            command.Parameters.AddWithValue("@pswrd", pswrd);
                                            command.ExecuteNonQuery();
                                        }

                                        //dAdapter.InsertCommand = insertCmd;
                                        //dAdapter.InsertCommand.ExecuteNonQuery();

                                        dbConn.Close();



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


        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
    }
}
