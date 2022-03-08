using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTO.Results
{
    public class UserUpdatedResult
    {
        public bool Sussess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public UserDTO User { get; set; }
    }
}
