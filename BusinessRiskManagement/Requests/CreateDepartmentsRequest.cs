using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Requests
{
    public class CreateDepartmentsRequest
    {
        public List<CreateDepartmentRequest> Departments { get; set; } = 
            new List<CreateDepartmentRequest>();
    }
}
