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
    public class RenteeRepository: BaseRepository<Rentee>,IRenteeRepository
    {
        public RenteeRepository(LibraryDbContext dbContext): base(dbContext)
        {

        }
    }
}
