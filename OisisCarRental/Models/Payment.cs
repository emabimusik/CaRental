using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OisisCarRental.Models
{
    public class Payment
    {

        public int Id { get; set; }
        public int Amount { get; set; }
        public PayMethod PayMethod { get; set; }
        public int PayMetId { get; set; }
        public PayStatus PayStatus { get; set; }
        public int PayStaId { get; set; }
        private DateTime _SetDefault = DateTime.Now;
       
        public DateTime PayedOn
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
        
      

    }
}