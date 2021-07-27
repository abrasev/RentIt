using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Car : AuditableBaseEntity
    {
        public string Maker { get; set; }
        public string Model { get; set; }
        public int YearProduced { get; set; }
        public string Color { get; set; }
        public bool Rented { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public int PricePerDay { get; set; }
        public string Photos { get; set; }

        public Rentee Rentee { get; set; }
    }
}
