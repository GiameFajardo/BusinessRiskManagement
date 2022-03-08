using Core.Application.DTO;
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

        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> RegisterAsync(string email, string name, string password, string companyName);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Guid GetOrganizationContext();
    }
}
