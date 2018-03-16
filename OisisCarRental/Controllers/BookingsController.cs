using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OisisCarRental.Models;
using OisisCarRental.Models.Repository;
using OisisCarRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static OisisCarRental.Models.ApplicationUser;

namespace OisisCarRental.Controllers
{
    
    public class BookingsController : Controller
    {
        private ApplicationDbContext _context;
        private BookingRepository _repository;
        public BookingsController()
        {
            _repository = new BookingRepository();
            _context = new ApplicationDbContext();
        }


       
        // GET: Bookings
        [Authorize]
        public ActionResult Index()
        {

            // var user = User.Identity.Name;
            // ApplicationDbContext context = new ApplicationDbContext();
            // var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // bool isAdmin = UserManager.;


            if (User.Identity.IsAuthenticated)
            {

                var userEmail = User.Identity.Name;
                
                  var BookingEmail = _repository.GetEmail(userEmail);
             

                return View(BookingEmail);
            }
            else
            {

                var bookings = _repository.GetAllbookings();
                return View("Index", bookings);
            }
        }
        public ActionResult Create()
        {
            //IEnumerable<ZipCode> zipcodes;

            // Need to refactor back to the repository to encapsulate the context



            var zipcodes = _repository.GetZipAll();
            
            var ZipBooking = new ZipBokingViewModel
            {
                    ZipCodes = zipcodes
            };


            ViewBag.date = DateTime.Now.ToString();
            return View("Create", ZipBooking);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,FromDate,ToDate,S_address,Address,D_address,Email_Bk,Contact_no,Amount,ZipId")]Booking booking)
        {

            if (ModelState.IsValid)
            { 
                _repository.Create(booking);
                return   RedirectToAction("Index");
            }
            else
            {
              return  RedirectToAction("Create");
            }

        }
        /**
        public ActionResult Loaddata()
        {

            // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var data2 = _repository.GetAllbookings();
            if (User.Identity.IsAuthenticated)
            {

                var userEmail = User.Identity.GetUserName();
                
               

               // return View("ReadOnLy", BookingEmail);
            
            var data = _repository.GetEmail(userEmail);
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
        }
      */
    }
}