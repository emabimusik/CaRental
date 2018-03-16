using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class Booking
    {
        
        public int  Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Pick up Date and Time")]
        public DateTime FromDate { get; set; }
        [Required]
        [Display(Name = "Return Date and Time")]
        public DateTime ToDate { get; set; }
        [Display(Name = "CreatedOn ")]
      
        private DateTime _SetDefault = DateTime.Now;

        public DateTime CreatedOn
        {
            get
            {
                return _SetDefault;
            }

            set
            {

                _SetDefault = value;
            }

        }
        [Required]
        [Display(Name = "Pick up Address")]
        public string S_address { get; set; }
        [Required]
        [Display(Name = "Returning Address")]
        public string D_address { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email_Bk { get; set; }
        [Required]
        [Display(Name = "Contact No")]
        public string Contact_No { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public int Amount { get; set; }
        [Display(Name = "Pck Up Location")]
        public string Address { get; set; }

        public ZipCode Zipcode { get; set; }
        public int ZipId { get; set; }
        /**
        public Bank Bank { get; set; }
        public int BankId { get; set; }
        public Status Status { get; set; }
        public int  StatusId { get; set; }*/
    }

   
}