using OisisCarRental.Models;
using OisisCarRental.Models.Repository;
using OisisCarRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OisisCarRental.Controllers
{
    public class PaymentsController : Controller
    {
        private PaymentRepository _repository;

        public PaymentsController()
        {
            _repository = new PaymentRepository();
        }
        // GET: Payments

        public ActionResult Index()
        {
            var payemnts = _repository.GetAllPayments();
            return View(payemnts);
        }
        public ActionResult Create()
        {

         
            var payMethods = _repository.GetAllPayMethod();
            var status = _repository.GetAllStatus();
            ViewBag.date = DateTime.Now;
            var paymentViewModel = new PaymentViewModel
            {
                Paymethods = payMethods,
                PayStatuses = status

            };
            return View("Create",paymentViewModel);
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "PayMetId,Amount,PayStaId")]Payment payment)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(payment);
                return RedirectToAction("Index");
            }
            var payMethods = _repository.GetAllPayMethod();
            var status = _repository.GetAllStatus();
            ViewBag.date = DateTime.Now;
            var paymentViewModel = new PaymentViewModel
            {
                Paymethods = payMethods,
                PayStatuses = status

            };
            return View("Create", paymentViewModel);

        }



        public ActionResult Print()
        {
            return View();
        }
    }
}