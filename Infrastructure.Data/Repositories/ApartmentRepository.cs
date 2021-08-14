using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ApartmentRepository: BaseRepository<Apartment>, IApartmentRepository
    {
        private readonly DbSet<Apartment> _apartments;
        public ApartmentRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _apartments = dbContext.Set<Apartment>();
        }
        public IEnumerable<Apartment> FullTextSearch(string searchTerm)
        {
            return _apartments.AsEnumerable().Where(a => (a.Address.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            || a.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) && a.Rented == false);
        }
    }
}
