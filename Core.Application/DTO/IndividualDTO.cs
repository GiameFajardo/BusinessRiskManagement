using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class IndividualDTO: OrganizacionDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
