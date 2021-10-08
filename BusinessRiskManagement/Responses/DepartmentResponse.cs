using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Responses
{
    public class DepartmentResponse
    {
        public string Name { get; set; }
        public Guid? FatherDepartmentId { get; set; }
        public DepartmentResponse FatherDepartment { get; set; }
    }
}
