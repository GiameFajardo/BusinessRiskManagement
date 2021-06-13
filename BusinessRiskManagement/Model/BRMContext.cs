using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Model
{
    public class BRMContext : DbContext
    {
        public BRMContext(DbContextOptions<BRMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Individual>();
            modelBuilder.Entity<Company>();
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Organizacion> Organizacions { get; set; }
    }
}
