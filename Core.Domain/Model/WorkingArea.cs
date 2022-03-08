using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class WorkingArea: UniqueEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WorkingAreaAssignation> WorkingAreaAssignations { get; set; }
    }
}
