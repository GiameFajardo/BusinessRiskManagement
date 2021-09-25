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
        public Guid? OrganizationId { get; set; }
        public virtual Organizacion Organizacion { get; set; }
    }
}
