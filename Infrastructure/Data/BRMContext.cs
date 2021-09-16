using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Contracts.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class BRMContext : IdentityDbContext, IBRMContext
    {
        public BRMContext(DbContextOptions<BRMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Individual>();
            modelBuilder.Entity<Company>();
            modelBuilder.Entity<Company>().HasData(new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Test Company",
                Enabled = true
            });
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Organizacion> Organizacions { get; set; }
    }
}
