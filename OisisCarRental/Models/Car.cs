using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public CarBrand CarBrand { get; set; }
        public int CarBrandId { get; set; }
        [Required]
        [Display(Name = "The model")]
        public string Model_Name { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string Color { get; set; }
        public CarType CarType { get; set; }
        public int CarTypeId { get; set; }
        [Display(Name = "No Seat")]
        public int Number_Seat { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
      
        [Display(Name = "Image")]
        public byte[] CarPhoto { get; set; }
     
        public FuelType FuelType { get; set; }
        public int FuelTypeId { get; set; }

        [Display(Name = "CreateOn")]
       
        private DateTime _DefaultTime = DateTime.Now;

        public DateTime CreatedOn {
            get
            {
                return _DefaultTime;
            }
           set
            {
                _DefaultTime = value;
            }
        }
        public string Location { get; set; }
        
      


    }
}