﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Responses.WorkingArea
{
    public class WorkingAreaResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserResponse> Users { get; set; }
    }
}
