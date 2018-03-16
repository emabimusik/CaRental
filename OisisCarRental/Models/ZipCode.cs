using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class ZipCode
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Poste Code")]
        public string PostNumber { get; set; }
        [Required]
        [Display(Name = "Post Number")]
        public string Commune { get; set; }
    }
}