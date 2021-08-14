using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RentApartmentViewModel
    {
        public RenteeViewModel Rentee { get; set; }
        public IEnumerable<ApartmentViewModel> Apartments{ get; set; } = Enumerable.Empty<ApartmentViewModel>();
    }
}
