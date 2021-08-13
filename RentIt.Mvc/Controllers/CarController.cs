using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentIt.Mvc.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            var carsListModel = _carService.GetCars();

            return View(carsListModel);
        }
        public IActionResult AddOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }
            var editedCarViewModel = _carService.GetCarById(id);
            return View(editedCarViewModel);
        }
        [HttpPost]
        public IActionResult AddOrEdit(CarViewModel carViewModel)
        {
            if (carViewModel.Id == Guid.Empty)
            {
                _carService.AddCar(carViewModel);
            }
            else
            {
                _carService.EditCar(carViewModel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(CarViewModel carViewModel)
        {
            _carService.EditCar(carViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet("Car/getAllCars")]
        public IActionResult GetAll()
        {
            var carsListModel = _carService.GetCars();
            if (carsListModel != null)
            {
                string json = JsonConvert.SerializeObject(
                       carsListModel,
                       Formatting.None,
                       new JsonSerializerSettings()
                       {
                           ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                           NullValueHandling = NullValueHandling.Ignore
                       });
                return Ok(json);
            }
            return NotFound();
        }
    }    
}
