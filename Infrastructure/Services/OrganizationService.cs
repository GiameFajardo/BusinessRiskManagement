using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly BRMContext _brmContext;

        public OrganizationService(BRMContext brmContext)
        {
            _brmContext = brmContext;
        }
        public List<OrganizacionDTO> GetAll()
        {
            return new List<OrganizacionDTO>();
            //return _brmContext.Organizacions.Select(o => new OrganizacionDTO { Id = o.Id, Enabled = o.Enabled }).;
        }

        public async Task Create(OrganizacionDTO org)
        {
            var organization = new Company
            {
               
                Enabled = true,
                Name = org.Name
            };
            
            _brmContext.Organizacions.Add(organization);
            await _brmContext.SaveChangesAsync();
        }
    }
}
