using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Requests
{
    public class CreateOrganizationRequest
    {

        public bool Enabled { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
