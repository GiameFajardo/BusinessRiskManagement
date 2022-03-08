using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class AuthenticationResult2
    {
        public string Token { get; set; }
        public bool Sussess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
