using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtectYou.Models;
using System.Data.SqlClient;

namespace ProtectYou.Controllers.NeedyOperations
{
    public class UploadPostController : Controller
    {
        SqlConnection dbConn = new SqlConnection(@"Data Source=DESKTOP-7KVCKFN\SQLEXPRESS;Initial Catalog=ProtectYou;Integrated Security=True;MultipleActiveResultSets=True");
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        public IActionResult UploadPost()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult UploadPost(PostRequirements post)
        {
            string status = "Success";
            string requirements = HttpContext.Request.Form["requirement"];
            double money = Convert.ToDouble(HttpContext.Request.Form["money"]);
            string description = HttpContext.Request.Form["description"];

            if(requirements != "" && money > 0 && description != "")
            {
                status = "";
                dbConn.Open();
                string qry = "INSERT INTO postRequest (requirement,quantity,description) Values('" + requirements + "', '" + money + "', '" + description + "')";
                SqlCommand insertCmd = new SqlCommand(qry, dbConn);
                dAdapter.InsertCommand = insertCmd;
                dAdapter.InsertCommand.ExecuteNonQuery();

                dbConn.Close();



                status = "Data inserted Successfully.";
            }
            else
            {
                status = "Form fields should not be empty.";
            }

            return Content(status);
        }
    }
}
