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
        List<OrganizacionDTO> GetAll();
        Task Create(CompanyDTO org);
    }
}
