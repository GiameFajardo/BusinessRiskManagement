using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
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

        public readonly UserManager<ApplicationUser> _userManager;

        public OrganizationService(BRMContext brmContext, UserManager<ApplicationUser> userManager)
        {
            _brmContext = brmContext;
            _userManager = userManager;
        }
        public List<CompanyDTO> GetAll()
        {
           // return new List<OrganizacionDTO>();
            var result =  _brmContext.Companies
                .Select(o => new CompanyDTO { Id = o.Id, Enabled = o.Enabled, Name = o.Name}).ToList();
            return result;
        }

        public async Task<Guid> Create(CompanyDTO org)
        {
            var organization = new Company
            {

                Enabled = true,
                Name = org.Name
            };

            var result = await _brmContext.Organizacions.AddAsync(organization);
            await _brmContext.SaveChangesAsync();
            return result.Entity.Id;
        }
        public async Task<Guid> CreateAndAsign(CompanyDTO org, Guid userId)
        {
            var organization = new Company
            {

                Enabled = true,
                Name = org.Name
            };

            var result = await _brmContext.Organizacions.AddAsync(organization);

            var userToAsign  = await _userManager.FindByIdAsync(userId.ToString());
            userToAsign.OrganizationId = result.Entity.Id;
            await _userManager.UpdateAsync(userToAsign);
            await _brmContext.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
