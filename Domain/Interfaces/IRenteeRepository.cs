using Domain.Interfaces.Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRenteeRepository: IBaseRepository<Rentee>
    {
        Rentee GetRenteeWithRentedCars(Guid id);
        Rentee GetRenteeWithRentedApartments(Guid id);
    }
}
