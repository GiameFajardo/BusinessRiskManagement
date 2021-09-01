using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Individual: Organizacion
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
