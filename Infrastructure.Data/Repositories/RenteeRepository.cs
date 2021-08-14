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
    public class RenteeRepository: BaseRepository<Rentee>,IRenteeRepository
    {
        private readonly LibraryDbContext _dbContext;
        public RenteeRepository(LibraryDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Rentee GetRenteeWithRentedCars(Guid id)
        {
            return _dbContext.Rentees.Include(x => x.Cars).First(rentee => rentee.Id == id);
            
        }
        public Rentee GetRenteeWithRentedApartments(Guid id)
        {
            return _dbContext.Rentees.Include(x => x.Apartments).First(rentee => rentee.Id == id);
            
        }
        public Rentee GetRenteeWithRentedCarsAndApartments(Guid id)
        {
            return _dbContext.Rentees.Include(x => x.Cars).Include(x => x.Apartments).First(rentee => rentee.Id == id);

        }
    }
}
