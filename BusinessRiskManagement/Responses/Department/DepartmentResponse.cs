using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Responses.Department
{
    public class DepartmentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? FatherDepartmentId { get; set; }
        public DepartmentResponse FatherDepartment { get; set; }
    }
}
