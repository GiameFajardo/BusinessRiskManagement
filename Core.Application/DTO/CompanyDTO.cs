﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.DTO
{
    public class CompanyDTO: OrganizacionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
    }
}

