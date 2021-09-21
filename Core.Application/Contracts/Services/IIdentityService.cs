using Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IIdentityService
    {

        Task<AuthenticationResult> Register(string email, string password);
    }
}
