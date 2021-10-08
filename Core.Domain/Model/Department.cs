using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Department: UniqueEntity
    {
        public string Name { get; set; }
        public Guid? FatherDepartmentId { get; set; }
        public virtual Department FatherDepartment { get; set; }
    }
}
