using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public abstract class Organizacion: UniqueEntity
    {

        public bool Enabled { get; set; }
        public virtual IEnumerable<ApplicationUser> Users { get; set; }
    }
}
