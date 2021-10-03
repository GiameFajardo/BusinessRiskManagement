using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Responses
{
    public class OrganizationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string CompanyEnvironmentDescription { get; set; }
        public string SecurityAndHealthObjeptives { get; set; }
    }
}
