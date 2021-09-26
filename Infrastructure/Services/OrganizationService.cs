using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<CompanyDTO> GetByUserAsync(string userId)
        {
            var logedInUser = await _userManager.Users.
                Include(u => u.Organizacion).
                SingleOrDefaultAsync(u => u.Id == userId);
            var organizationId = logedInUser.OrganizationId;

            var company = await _brmContext.Companies.FindAsync(organizationId);
            var organizationDTO = new CompanyDTO
            {
                Enabled = company.Enabled,
                Name = company.Name,
                Id = company.Id,
                About = company.About,
                Phone = company.Phone,
                EMail = company.EMail,
                Address = company.Address
            };
            return organizationDTO;
        }

        public async Task<bool> Update(CompanyDTO organization)
        {

            var organizationToUpdate = await _brmContext.Companies.FindAsync(organization.Id);



            organizationToUpdate.Name = organization.Name;
            organizationToUpdate.About = organization.About;
            organizationToUpdate.Address = organization.Address;
            organizationToUpdate.EMail = organization.EMail;
            organizationToUpdate.Phone = organization.Phone;


            _brmContext.Entry(organizationToUpdate).State = EntityState.Modified;
            //_brmContext.Organizacions.Update(organizationToUpdate);
            var updated = await _brmContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
