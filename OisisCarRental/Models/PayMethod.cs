using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class PayMethod
    {
     public int Id { get; set; }
     [Required]
     public string Name { get; set; }
        /**
        public string OnlinePayment { get; set; }
        public string Paypal { get; set; }
        public string Card { get; set; }
        public string  BankTransfer { get; set; }
       */
    }
}