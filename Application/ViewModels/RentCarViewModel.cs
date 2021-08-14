using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RentCarViewModel
    {
        public RenteeViewModel Rentee { get; set; }
        public IEnumerable<CarViewModel> Cars { get; set; } = Enumerable.Empty<CarViewModel>();    
    }
}
