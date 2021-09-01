using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Data
{
    public interface IBRMContext
    {

        public DbSet<Organizacion> Organizacions { get; }

    }
}
