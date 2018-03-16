using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class Customer
    {
       // Usermaster
       //Table contains all User details e.g. (Username, Password)

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Contact_No { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
       // public ApplicationUser User { get; set; }
       // public string ApplicationUserId { get; set; }
        //UserType
        //Table contains all User type details e.g. (Admin, User)

       
    }
}