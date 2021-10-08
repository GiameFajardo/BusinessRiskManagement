using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Requests
{
    public class CreateDepartmentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? FatherDepartmentId { get; set; }
    }
}
