using OisisCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OisisCarRental.ViewModel
{
    public class ZipBokingViewModel
    {

        public IEnumerable<ZipCode> ZipCodes { get; set; }
        public Booking Booking { get; set; }
    }
}