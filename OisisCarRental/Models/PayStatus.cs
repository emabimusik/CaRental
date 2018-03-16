using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class PayStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        /**
        public int Id { get; set; }
        public bool Paid { get; set; }
        public bool NotPaid { get; set; }
        public bool Pending { get; set; }
        public bool Cancel { get; set; }
       */
    }
}