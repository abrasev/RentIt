using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarService
    {
        CarListViewModel GetCars();
        CarViewModel GetCarById(Guid id);
        CarViewModel AddCar(CarViewModel carRequest);
        void EditCar(CarViewModel carRequest);
        CarListViewModel FullTextSearch(string searchTerm);

    }
}
