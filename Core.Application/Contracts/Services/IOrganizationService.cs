using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IOrganizationService
    {
        List<CompanyDTO> GetAll();
        Task<Guid> Create(CompanyDTO org);
        Task<Guid> CreateAndAsign(CompanyDTO org, Guid userId);
        Task<CompanyDTO> GetByUserAsync(string userId);
        Task<bool> Update(CompanyDTO organization);
    }
}
