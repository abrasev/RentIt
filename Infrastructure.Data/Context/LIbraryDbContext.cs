using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options): base(options)
        {

        }
        public DbSet<Rentee> Rentees { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
