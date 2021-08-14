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
    public class RenteeService : IRenteeService
    {
        private readonly IRenteeRepository _renteeRepository;
        private readonly ICarRepository _carRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        public RenteeService(IRenteeRepository renteeRepository, ICarRepository carRepository, IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _renteeRepository = renteeRepository;
            _carRepository = carRepository;
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }
        public RenteeViewModel AddRentee(RenteeViewModel renteeRequest)
        {
            var mapRentee = _mapper.Map<Rentee>(renteeRequest);
            var addRentee = _renteeRepository.Add(mapRentee);
            return _mapper.Map<RenteeViewModel>(addRentee);
        }

        public void EditRentee(RenteeViewModel renteeRequest)
        {
            var mapRentee = _mapper.Map<Rentee>(renteeRequest);
            _renteeRepository.Update(mapRentee);
        }

        public RenteeListViewModel GetAllRentees()
        {
            var allRentees = _renteeRepository.GetAll();
            var allRentieesMapped = _mapper.Map<IEnumerable<RenteeViewModel>>(allRentees);
            return new RenteeListViewModel()
            {
                Rentees = allRentieesMapped
            };
        }

        public RenteeViewModel GetRenteeById(Guid id)
        {
            var rentee = _renteeRepository.GetById(id);
            return _mapper.Map<RenteeViewModel>(rentee);
        }
        public RentCarViewModel GetRenteeWithRentedCars(Guid id)
        {
            var rentee = _renteeRepository.GetRenteeWithRentedCars(id);

            var renteeViewModel = _mapper.Map<RenteeViewModel>(rentee);
            var carsVm = _mapper.Map<IEnumerable<CarViewModel>>(rentee.Cars);

            return new RentCarViewModel
            {
                Cars = carsVm,
                Rentee = renteeViewModel
            };
        }
        public void RentCar(Guid carId, Guid renteeId)
        {
            var car = _carRepository.GetById(carId);
            if (car.Rented == true)
            {
                throw new Exception($"You cant rent Rented Car");
            }

            var rentee = _renteeRepository.GetById(renteeId);
            car.Rentee = new Rentee();
            car.Rentee = rentee;

            rentee.Cars = new List<Car>();

            rentee.Cars.Add(car);

            car.Rented = true;
            _carRepository.Update(car);
        }        
        public void ReturnCar(Guid carId, Guid renteeId)
        {
            var car = _carRepository.GetById(carId);

            var rentee = _renteeRepository.GetRenteeWithRentedCars(renteeId);

            rentee.Cars.Remove(car);

            car.Rented = false;
            _carRepository.Update(car);
        }        
        public RentApartmentViewModel GetRenteeWithRentedApartments(Guid id)
        {
            var rentee = _renteeRepository.GetRenteeWithRentedApartments(id);

            var renteeViewModel = _mapper.Map<RenteeViewModel>(rentee);
            var apartmenVm = _mapper.Map<IEnumerable<ApartmentViewModel>>(rentee.Apartments);

            return new RentApartmentViewModel
            {
                Rentee = renteeViewModel,
                Apartments = apartmenVm
            };
        }
        public void RentApartment(Guid apartmentId, Guid renteeId)
        {
            var apartment = _apartmentRepository.GetById(apartmentId);
            var rentee = _renteeRepository.GetRenteeWithRentedApartments(renteeId);

            rentee.Apartments = new List<Apartment>();
            apartment.Rentees = rentee;

            rentee.Apartments.Add(apartment);

            apartment.Rented = true;
            _apartmentRepository.Update(apartment);
        }

        public void ReturnApartment(Guid apartmentId, Guid renteeId)
        {
            var apartment = _apartmentRepository.GetById(apartmentId);
            var rentee = _renteeRepository.GetRenteeWithRentedApartments(renteeId);

            rentee.Apartments = new List<Apartment>();
            apartment.Rentees = rentee;

            rentee.Apartments.Remove(apartment);

            apartment.Rented = false;
            _apartmentRepository.Update(apartment);
        }
    }
}
