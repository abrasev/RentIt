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
    }
}
