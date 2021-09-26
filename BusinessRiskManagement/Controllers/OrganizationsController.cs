
using Core.Application.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Application.Contracts.Services;
using BusinessRiskManagement.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessRiskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public ActionResult<OrganizacionDTO> Get()
        {
            return Ok(_organizationService.GetAll());
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
                Name = request.Name
            };
            await _organizationService.CreateAndAsign(organization, request.UserId);
            return Ok();
        }

    }
}
