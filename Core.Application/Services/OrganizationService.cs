using Core.Application.Contracts.Data;
using Core.Application.Data.Services;
using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IBRMContext _brmContext;

        public OrganizationService(IBRMContext brmContext)
        {
            _brmContext = brmContext;
        }
        public List<OrganizacionDTO> GetAll()
        {
            return new List<OrganizacionDTO>();
            //return _brmContext.Organizacions.Select(o => new OrganizacionDTO { Id = o.Id, Enabled = o.Enabled }).;
        }
    }
}
