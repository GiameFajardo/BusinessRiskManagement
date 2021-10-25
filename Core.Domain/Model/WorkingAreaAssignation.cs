using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class WorkingAreaAssignation:UniqueEntity
    {
        public Guid WorkingAreaId { get; set; }
        public WorkingArea WorkingArea { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
