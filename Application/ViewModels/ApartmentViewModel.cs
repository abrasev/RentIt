using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ApartmentViewModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        [Display(Name ="Beds")]
        public int Bads { get; set; }
        public string City { get; set; }
        public bool Rented { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public int PricePerNight { get; set; }
        public string Photos { get; set; }        
    }
}
