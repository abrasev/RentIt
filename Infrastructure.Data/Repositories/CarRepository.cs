using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CarRepository: BaseRepository<Car>, ICarRepository
    {
        public CarRepository(LibraryDbContext dbContext): base(dbContext)
        {

        }
    }
}
