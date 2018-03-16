using OisisCarRental.Models;
using OisisCarRental.Models.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OisisCarRental.ViewModel;
using System.Collections;
using static OisisCarRental.Models.ApplicationUser;
using System.Text;

namespace OisisCarRental.Controllers
{
    public class CarsController : Controller
    {
       
        private CarRepository _repository;
        public CarsController()
        {
            _repository = new CarRepository();
           
        }
        // GET: Cars
        public ActionResult Index()
        {
            var carList = _repository.GEtAllCar();
           
            return View(carList);
        }
        //Location
        public ActionResult Location()
        {
            var carList = _repository.GEtAllCar();
            return View(carList);
        }


        public ActionResult Create()
        {
            
         
            var carviewModel = new CarsViewModel
            {
                 //Car = _context.Cars,
                 CarBrands = _repository.GetCarBrands(),
                 CarTypes = _repository.GetCarTypes(),
                 FuelTypes = _repository.GetFuelTypes()
            };
            ViewBag.date = DateTime.Now.ToString();
            return View(carviewModel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "CarBrandId,Model_Name,Color,CarTypeId,Number_Seat,Price ,FuelTypeId,Location")]Car car)

        {
           
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["carPhoto"];
                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }



                }
                car.CarPhoto = imageData;
                _repository.CreateCar(car);
                return RedirectToAction("Index");

            }
            
            return RedirectToAction("Create");
            

        }
    }
}