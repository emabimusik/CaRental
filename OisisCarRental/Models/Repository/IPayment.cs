using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OisisCarRental.Models.Repository
{
    public interface IPayment
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetPayementById(int id);
        void Delete(int id);
        void Update(Payment payment);
        void Create(Payment payment);



    }
}
