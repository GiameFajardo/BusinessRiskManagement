using AutoMapper;
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
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public OrganizationService(
            BRMContext brmContext, 
            UserManager<ApplicationUser> userManager,
            IStorageService storageService,
            IMapper mapper)
        {
            _brmContext = brmContext;
            _userManager = userManager;

            this._storageService = storageService;
            this._mapper = mapper;
        }
        public List<CompanyDTO> GetAll()
        {
            var companies = _brmContext.Companies.ToList();
            var companiesToReturn = _mapper.Map<List<CompanyDTO>>(companies);
            return companiesToReturn;
        }

        public async Task<Guid> Create(CompanyDTO org)
        {
            var organization = new Company
            {

                Enabled = true,
                Name = org.Name,
                About = org.About,
                Phone = org.Phone,
                SecurityAndHealthObjeptives = org.SecurityAndHealthObjeptives,
                CompanyEnvironmentDescription = org.CompanyEnvironmentDescription,
                Address = org.Address,
                EMail = org.EMail,
                Photo = org.PhotoURL
            };

            var result = await _brmContext.Organizacions.AddAsync(organization);
            await _brmContext.SaveChangesAsync();
            return result.Entity.Id;
        }
        public async Task<Guid> CreateAndAsign(CompanyDTO org, Guid userId)
        {
            var organization = _mapper.Map<Company>(org);

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
                //Include(u => u.Organizacion).
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
                Address = company.Address,
                PhotoURL = company.Photo,
                CompanyEnvironmentDescription = company.CompanyEnvironmentDescription,
                SecurityAndHealthObjeptives = company.SecurityAndHealthObjeptives
            };
            return organizationDTO;
        }

        public async Task<bool> Update(CompanyDTO organization)
        {

            var organizationToUpdate = await _brmContext.Companies.FindAsync(organization.Id);

            if (organization.PhotoFile != null && organization.PhotoFile.Length > 0)
            {
                var url = await  _storageService.UpdateOrganizationPhotoAsync(organization.PhotoFile);
                organizationToUpdate.Photo = url;
            }

            organizationToUpdate.Name = organization.Name;
            organizationToUpdate.About = organization.About;
            organizationToUpdate.Address = organization.Address;
            organizationToUpdate.EMail = organization.EMail;
            organizationToUpdate.Phone = organization.Phone;
            organizationToUpdate.SecurityAndHealthObjeptives = organization.SecurityAndHealthObjeptives;
            organizationToUpdate.CompanyEnvironmentDescription = organization.CompanyEnvironmentDescription;

            _brmContext.Entry(organizationToUpdate).State = EntityState.Modified;
            //_brmContext.Organizacions.Update(organizationToUpdate);
            var updated = await _brmContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
