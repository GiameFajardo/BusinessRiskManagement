using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Core.Domain.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
        public Guid? OrganizationId { get; set; }
        public virtual Organizacion Organizacion { get; set; }

        public virtual ICollection<WorkingAreaAssignation> WorkingAreaAssignations { get; set; }
    }
}
