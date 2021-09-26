using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Data
{
    public interface IBRMContext
    {

        public DbSet<Organizacion> Organizacions { get; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> Users { get; }
    }
}
