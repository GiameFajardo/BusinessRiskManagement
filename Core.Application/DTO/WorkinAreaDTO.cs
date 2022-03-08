using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class WorkinAreaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
