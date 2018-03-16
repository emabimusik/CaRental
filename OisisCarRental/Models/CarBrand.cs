using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        [Required]
       
        public string Name { get; set; }
    }
}