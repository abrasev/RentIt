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
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }
        public ApartmentViewModel AddApartment(ApartmentViewModel apartmentRequest)
        {
            var apartment = _mapper.Map<Apartment>(apartmentRequest);
            var apartmentViewModel = _apartmentRepository.Add(apartment);
            return _mapper.Map<ApartmentViewModel>(apartmentViewModel);
        }

        public void EditApartment(ApartmentViewModel apartmentRequest)
        {            
            var apartment = _mapper.Map<Apartment>(apartmentRequest);
            _apartmentRepository.Update(apartment);
        }

        public ApartmentListViewModel GetAllApartments()
        {
            var apartments = _apartmentRepository.GetAll();
            var apartmentsViewModel = _mapper.Map<IEnumerable<ApartmentViewModel>>(apartments);
            return new ApartmentListViewModel()
            {
                Apartments = apartmentsViewModel
            };
        }

        public ApartmentViewModel GetApartmentById(Guid id)
        {
            var apartment = _apartmentRepository.GetById(id);
            return _mapper.Map<ApartmentViewModel>(apartment);
        }

        public ApartmentListViewModel SearchByFullname(string searchTerm)
        {
            var apartmentsVm = new List<ApartmentViewModel>();

            var apartment = _apartmentRepository.GetAll().Where(a => a.Rented == false);

            var apartments = string.IsNullOrEmpty(searchTerm) ? apartment : _apartmentRepository.FullTextSearch(searchTerm);

            if (apartments != null && apartments.Any())
            {
                apartmentsVm = _mapper.Map<List<ApartmentViewModel>>(apartments);
            }
            return new ApartmentListViewModel
            {
                Apartments = apartmentsVm
            };
        }
    }
}
