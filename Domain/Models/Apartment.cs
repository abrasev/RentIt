using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Apartment : AuditableBaseEntity
    {
        public string Address { get; set; }
        public int Bads { get; set; }
        public string City { get; set; }
        public bool Rented { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public int PricePerNight { get; set; }
        public string Photos { get; set; }
        public Rentee Rentees {get;set;}
    }
}
