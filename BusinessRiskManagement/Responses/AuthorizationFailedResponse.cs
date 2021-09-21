using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Responses
{
    public class AuthorizationFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
