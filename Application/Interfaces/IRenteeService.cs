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
    }
}
