using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OisisCarRental.Models.Repository
{
    public interface IBooking
    {
        IEnumerable<Booking> GetAllbookings();
        Booking GetBookingById(int id);
        void Create(Booking booking);
        void Update(Booking booking);
        void Delete(int id);


    }
}
