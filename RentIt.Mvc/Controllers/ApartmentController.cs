using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentIt.Mvc.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        public IActionResult Index()
        {
            var apartments = _apartmentService.GetAllApartments();
            return View(apartments);
        }
        public IActionResult AddOrEdit(Guid id)
        {
            var apartment = _apartmentService.GetApartmentById(id);
            if (id == Guid.Empty)
            {
                return View();
            }
            return View(apartment);
        }
        [HttpPost]
        public IActionResult AddOrEdit(ApartmentViewModel apartmentViewModel)
        {
            if (apartmentViewModel.Id == Guid.Empty)
            {
                _apartmentService.AddApartment(apartmentViewModel);
            }
            else
            {
                _apartmentService.EditApartment(apartmentViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
