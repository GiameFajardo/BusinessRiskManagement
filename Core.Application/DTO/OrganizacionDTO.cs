using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public abstract class OrganizacionDTO: UniqueEntity
    {

        public bool Enabled { get; set; }
    }
}
