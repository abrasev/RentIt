using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApartmentService
    {
        ApartmentListViewModel GetAllApartments();
        ApartmentViewModel GetApartmentById(Guid id);
        ApartmentViewModel AddApartment(ApartmentViewModel apartmentRequest);
        void EditApartment(ApartmentViewModel apartmentRequest);
    }
}
