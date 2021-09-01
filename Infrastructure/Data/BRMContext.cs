using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Contracts.Data;

namespace Infrastructure.Data
{

    public class BRMContext : DbContext, IBRMContext
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
