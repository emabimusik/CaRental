using OisisCarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OisisCarRental.ViewModel
{
    public class PaymentViewModel
    {
       public IEnumerable<PayMethod> Paymethods { get; set; }
       public IEnumerable<PayStatus> PayStatuses { get; set; }
      
       public Payment Payment { get; set; }

    }

}