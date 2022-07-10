using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProtectYou.Models
{
    public class RegistrationModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int FamilyMember { get; set; }        //Needy only
        public string passwd { get; set; }
        public string cpasswd { get; set; }
        public DateTime dateOfRegistration { get; set; }  //NGO's organization registration date
        public string registrationNumber { get; set; }    //NGO's organization registration number
        public string Image { get; set; }                 // NGO 
        public string registeredWith { get; set; }        //NGO's is registered where and where
        public Double currentAnnualBudget { get; set; }   // NGO
        public string gender { get; set; }                // Donors  
        public string occupation { get; set; }                // Donors  

    }
}
