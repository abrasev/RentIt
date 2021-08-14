using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CarViewModel
    {
        public Guid Id { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        [Display(Name ="Year Produced")]
        public int YearProduced { get; set; }
        public string Color { get; set; }
        public bool Rented { get; set; }
        [Display(Name = "Rented On")]
        public DateTime RentedOn { get; set; }
        [Display(Name = "Returned On")]
        public DateTime ReturnedOn { get; set; }
        [Display(Name = "Price Per Day")]
        public int PricePerDay { get; set; }
        public string Photos { get; set; }
        public string FullName { get
            {
                return $"{Maker} {Model}";
            } 
        }
    }
}
