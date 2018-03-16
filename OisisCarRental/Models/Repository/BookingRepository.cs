using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using static OisisCarRental.Models.ApplicationUser;

namespace OisisCarRental.Models.Repository
{
    public class BookingRepository : IBooking ,IDisposable
    {
        private ApplicationDbContext _context;
        public BookingRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var booking = _context.Bookings.Single(b=>b.Id==id);
            _context.Bookings.Remove(booking);
            _context.SaveChanges();

        }
        public IEnumerable<String>  GetPostNumber()
        {
            //SELECT DISTINCT PostNumber FROM ZipCodes
            var postNumber = _context.ZipCodes.Select(x => x.PostNumber).ToList();
            return postNumber;
        }
        public IEnumerable<String> GetCommune()
        {
            //SELECT DISTINCT PostNumber FROM ZipCodes
            var commune = _context.ZipCodes.Select(x=>x.Commune).ToList();
            return commune;
        }

        public IEnumerable< Booking >GetEmail(string email)
        {
           
            var Booking = _context.Bookings.Where(x => x.Email_Bk == email).ToList();
            return Booking ;

            
        }
        public IEnumerable<ZipCode> GetZipAll()
        {
            return _context.ZipCodes.ToList();
        }


        public IEnumerable<Booking> GetAllbookings()

        {


            var bookings = _context.Bookings.ToList();
            return bookings;
        }

        public Booking GetBookingById(int id)
        {
            var booking = _context.Bookings.Single(b=>b.Id ==id);
            return booking;
        }

        public void Update(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
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