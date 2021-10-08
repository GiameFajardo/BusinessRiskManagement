using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        public Guid OrganizacionId { get; set; }
        public string Name { get; set; }
        public Guid? FatherDepartmentId { get; set; }
        public DepartmentDTO FatherDepartment { get; set; }
    }
}
