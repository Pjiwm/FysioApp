using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class FysioDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public FysioDbContext(DbContextOptions<FysioDbContext> contextOptions) : base(contextOptions)
        {

        }
    }
}
