using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }
        public CarViewModel AddCar(CarViewModel carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            var addedCar = _carRepository.Add(car);
            return _mapper.Map<CarViewModel>(addedCar);
        }


        public void EditCar(CarViewModel carRequest)
        {
            var car = _mapper.Map<Car>(carRequest);
            _carRepository.Update(car);
        }

        public CarViewModel GetCarById(Guid id)
        {
            var car = _carRepository.GetById(id);
            return _mapper.Map<CarViewModel>(car);
        }

        public CarListViewModel GetCars()
        {
            var cars = _carRepository.GetAll();
            var carsViewModel = _mapper.Map<IEnumerable<CarViewModel>>(cars);
            return new CarListViewModel()
            {
                Cars = carsViewModel
            };
        }
        
    }
}
