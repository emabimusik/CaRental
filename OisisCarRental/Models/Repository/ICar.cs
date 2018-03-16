using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OisisCarRental.Models.Repository
{
     public interface ICar
    {
        IEnumerable<Car> GEtAllCar();
        Car GetCarById(int Id);
        void CreateCar(Car car);
        void Delete(int Id);
        void Update(Car car);
    }
}
