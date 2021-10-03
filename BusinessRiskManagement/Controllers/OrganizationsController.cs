
using Core.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Application.Contracts.Services;
using BusinessRiskManagement.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Domain.Model;
using BusinessRiskManagement.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessRiskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;


        public OrganizationsController(IOrganizationService organizationService
                                       )
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public ActionResult<OrganizacionDTO> Get()
        {
            return Ok(_organizationService.GetAll());
        }
        [HttpGet("byUser")]
        public async Task<ActionResult<OrganizationResponse>> GetByUser()
        {
            var userId = HttpContext.User.Claims.SingleOrDefault(c => c.Type == "id").Value;
            CompanyDTO organization = await _organizationService.GetByUserAsync(userId);
            var response = new OrganizationResponse
            {
                About = organization.About,
                Address = organization.Address,
                EMail = organization.EMail,
                Id = organization.Id,
                Name = organization.Name,
                Phone = organization.Phone,
                Photo = organization.PhotoURL,
                CompanyEnvironmentDescription = organization.CompanyEnvironmentDescription,
                SecurityAndHealthObjeptives = organization.SecurityAndHealthObjeptives
            };
            return Ok(response);
        }
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateOrganizationRequest request)
        {
            //var userId = HttpContext.User.Claims
            //    .SingleOrDefault(c => c.Type == "Id").Value;
            var userId = HttpContext.User.Claims.SingleOrDefault(c => c.Type == "Id");
            var organization = new CompanyDTO
            {
                Enabled = request.Enabled,
                Name = request.Name,
                About = request.About,
                Address = request.Address,
                EMail = request.EMail,
                Phone = request.Phone,
                CompanyEnvironmentDescription = request.CompanyEnvironmentDescription,
                SecurityAndHealthObjeptives = request.SecurityAndHealthObjeptives,
                PhotoURL = request.Phone,
                Id = request.Id
            };
            await _organizationService.CreateAndAsign(organization, request.UserId);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateCompany([FromForm] UpdateOrganizationRequest request)
        {

            var organization = new CompanyDTO
            {
                Name = request.Name,
                About = request.About,
                Phone = request.Phone,
                EMail = request.EMail,
                Address = request.Address,
                CompanyEnvironmentDescription = request.CompanyEnvironmentDescription,
                SecurityAndHealthObjeptives = request.SecurityAndHealthObjeptives,
                Id = request.Id,
                PhotoFile = request.Photo
            };
            bool updated = await _organizationService.Update(organization);
            return Created(organization.Id.ToString(), organization);
        }
    }
}
