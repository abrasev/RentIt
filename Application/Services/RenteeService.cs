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
        private readonly IMapper _mapper;
        public RenteeService(IRenteeRepository renteeRepository, IMapper mapper)
        {
            _renteeRepository = renteeRepository;
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

        public RentApartmentViewModel GetRenteeWithRentedApartments(Guid id)
        {
            var rentee = _renteeRepository.GetRenteeWithRentedApartments(id);

            var renteeViewModel = _mapper.Map<RenteeViewModel>(rentee);
            var apartmenVm = _mapper.Map<IEnumerable<ApartmentViewModel>>(rentee);

            return new RentApartmentViewModel
            {
                Rentee = renteeViewModel,
                Apartments = apartmenVm
            };
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
    }
}
