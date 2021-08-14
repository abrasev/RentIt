using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRenteeService
    {
        RenteeListViewModel GetAllRentees();
        RenteeViewModel GetRenteeById(Guid id);
        RenteeViewModel AddRentee(RenteeViewModel renteeRequest);
        void EditRentee(RenteeViewModel renteeRequest);
        RentCarViewModel GetRenteeWithRentedCars(Guid id);
        RentApartmentViewModel GetRenteeWithRentedApartments(Guid id);
        void RentCar(Guid carId, Guid renteeId);
        void ReturnCar(Guid renteeId, Guid carId);
        void RentApartment(Guid apartmentId, Guid renteeId);
        void ReturnApartment(Guid apartmentId, Guid renteeId);
    }
}
