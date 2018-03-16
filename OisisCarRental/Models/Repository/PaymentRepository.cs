using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static OisisCarRental.Models.ApplicationUser;

namespace OisisCarRental.Models.Repository
{
    public class PaymentRepository : IPayment, IDisposable
    {
        private ApplicationDbContext _context;

        public PaymentRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<PayMethod> GetAllPayMethod()
        {
            return _context.PayMethods.ToList();
        }
        public IEnumerable<PayStatus> GetAllStatus()
        {
            return _context.PayStatuses.ToList();
        }
        public void Create(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var payment = _context.Payments.Single(x => x.Id == id);
            _context.Payments.Remove(payment);
        }

        public IEnumerable<Payment> GetAllPayments()
        {

           var allPayment =_context.Payments.Include(p=>p.PayMethod)
                                            .Include(p=>p.PayStatus).ToList();
            return allPayment;
        }

        public Payment GetPayementById(int id)
        {
            var payment = _context.Payments.Single(x => x.Id == id);
            return payment;
        }

        public void Update(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}