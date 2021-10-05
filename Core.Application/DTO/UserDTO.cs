using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class UserDTO
    {
        //public  DateTimeOffset? LockoutEnd { get; set; }
        //public  bool TwoFactorEnabled { get; set; }

        //public virtual bool PhoneNumberConfirmed { get; set; }

        //public virtual string ConcurrencyStamp { get; set; }

        //public virtual string SecurityStamp { get; set; }

        //public virtual string PasswordHash { get; set; }

        //public virtual bool EmailConfirmed { get; set; }
        public string Id { get; set; }
        public virtual string NormalizedEmail { get; set; }
       
        public virtual string Email { get; set; }
        
        public virtual string NormalizedUserName { get; set; }
        
        public virtual string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }


        //public virtual bool LockoutEnabled { get; set; }
        //public virtual int AccessFailedCount { get; set; }
    }
}
