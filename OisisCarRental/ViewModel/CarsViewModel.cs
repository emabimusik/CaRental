using OisisCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OisisCarRental.ViewModel
{
    public class CarsViewModel
    {
        public IEnumerable<CarBrand> CarBrands { get; set; }
        public IEnumerable<CarType> CarTypes { get; set; }
        public IEnumerable<FuelType> FuelTypes { get; set; }
        public Car Car { get; set; }
    }
}