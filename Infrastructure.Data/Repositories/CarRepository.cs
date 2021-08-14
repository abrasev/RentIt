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
    public class CarRepository: BaseRepository<Car>, ICarRepository
    {
        private readonly DbSet<Car> _cars;
        public CarRepository(LibraryDbContext dbContext): base(dbContext)
        {
            _cars = dbContext.Set<Car>();
        }

        public IEnumerable<Car> FullTextSearch(string searchTerm)
        {
            return _cars.AsEnumerable().Where(c => (c.Maker.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            || c.Model.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) && c.Rented == false);
        }
    }
}
