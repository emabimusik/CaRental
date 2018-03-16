using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace OisisCarRental.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public DateTime DOB { get; set; }
       
        public string Address { get; set; }
       
        public int RePhoneNumber { get; set; }
       
        public byte[] UserPhoto { get; set; }
        private DateTime _SetDefault = DateTime.Now;

        public DateTime CreateOn
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
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

      

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("OasisCon", throwIfV1Schema: false)
            {
            }
            public DbSet<Car> Cars { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<PayMethod> PayMethods { get; set; }
            public DbSet<Payment> Payments { get; set; }
            public DbSet<PayStatus> PayStatuses { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<FuelType> FuelTypes { get; set; }
            public DbSet<CarType> CarTypes { get; set; }
            public DbSet<CarBrand> CarBrands { get; set; }
            public DbSet<ZipCode>  ZipCodes { get; set; }
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }


        }
    }
}