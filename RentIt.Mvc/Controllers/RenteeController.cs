using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentIt.Mvc.Controllers
{
    public class RenteeController : Controller
    {
        private readonly IRenteeService _renteeService;
        public RenteeController(IRenteeService renteeService)
        {
            _renteeService = renteeService;
        }
        public IActionResult Index()
        {
            var model = _renteeService.GetAllRentees();

            return View(model);
        }
        public IActionResult AddOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }
            var renteeViewModel = _renteeService.GetRenteeById(id);
            return View(renteeViewModel);            
        }
        [HttpPost]
        public IActionResult AddOrEdit(RenteeViewModel renteeViewModel)
        {            
            if (renteeViewModel.Id == Guid.Empty)
            {
                _renteeService.AddRentee(renteeViewModel);
            }
            else
            {
                _renteeService.EditRentee(renteeViewModel);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RentCar(Guid id)
        {
            RentCarViewModel model = _renteeService.GetRenteeWithRentedCars(id);

            return View(model);
        }
        [HttpPost]
        public IActionResult RentCar(Guid carId, Guid renteeId)
        {
            _renteeService.RentCar(carId, renteeId);

            var model = _renteeService.GetRenteeWithRentedCars(renteeId);

            return View(model);
        }
        public IActionResult ReturnCar(Guid renteeId)
        {
            RentCarViewModel model = _renteeService.GetRenteeWithRentedCars(renteeId);

            return View(model);
        }
        [HttpPost]
        public IActionResult ReturnCar(Guid carId, Guid renteeId)
        {
            _renteeService.ReturnCar(carId, renteeId);

            RentCarViewModel model = _renteeService.GetRenteeWithRentedCars(renteeId);

            return View("RentCar", model);
        }
                
        public IActionResult RentApartment(Guid id)
        {
            RentApartmentViewModel model = _renteeService.GetRenteeWithRentedApartments(id);

            return View(model);
        }
        [HttpPost]
        public IActionResult RentApartment(Guid apartmentId, Guid renteeId)
        {
            _renteeService.RentApartment(apartmentId, renteeId);

            var model = _renteeService.GetRenteeWithRentedApartments(renteeId);

            return View(model);
        }        
        public IActionResult ReturnApartment(Guid renteeId)
        {
            RentApartmentViewModel model = _renteeService.GetRenteeWithRentedApartments(renteeId);

            return View("RentApartment", model);
        }
        [HttpPost]
        public IActionResult ReturnApartment(Guid apartmentId, Guid renteeId)
        {
            _renteeService.ReturnApartment(apartmentId, renteeId);

            RentApartmentViewModel model = _renteeService.GetRenteeWithRentedApartments(renteeId);

            return View("RentApartment", model);
        }

    }
}
