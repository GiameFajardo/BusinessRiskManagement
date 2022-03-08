using Core.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Responses
{
    public class AuthorizationSussessResponse
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
