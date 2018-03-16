using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static OisisCarRental.Models.ApplicationUser;

namespace OisisCarRental.Models.Repository
{
    public class CarRepository : ICar, IDisposable
    {
        private ApplicationDbContext _context;

        public CarRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CarBrand> GetCarBrands()
        {
            return _context.CarBrands.ToList();
        }
        public IEnumerable<CarType> GetCarTypes()
        {
           return  _context.CarTypes.ToList();
        }
        public IEnumerable<FuelType> GetFuelTypes()
        {
            return _context.FuelTypes.ToList();
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.Single(x => x.Id == id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        

        public IEnumerable<Car> GEtAllCar()
        {
            return _context.Cars.Include(x=>x.CarBrand)
                                .Include(x=>x.FuelType)
                                .Include(x=>x.CarType).ToList();
        }
        
        public Car GetCarById(int id)
        {
            var car = _context.Cars.Single(x => x.Id == id);
            return car;
        }

        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
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