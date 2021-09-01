using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.Services
{
    public interface IOrganizationService
    {
        List<OrganizacionDTO> GetAll();
    }
}
