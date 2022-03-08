using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Requests
{
    public class CreateUserRequest
    {

        public string Identification { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
    }
}
