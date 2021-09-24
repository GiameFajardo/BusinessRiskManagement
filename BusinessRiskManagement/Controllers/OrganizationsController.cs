
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

        public readonly UserManager<IdentityUser> _userManager;
        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }


        // GET: api/<OrganizationsController>
        [HttpGet]
        public ActionResult<OrganizacionDTO> Get()
        {
            return Ok(_organizationService.GetAll());
        }

        //// GET api/<OrganizationsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<OrganizationsController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateOrganizationRequest orcanization)
        {
            var organization = new CompanyDTO
            {
                Enabled = orcanization.Enabled,
                Name = orcanization.Name
            };
            _organizationService.Create(organization);
            return Ok();
        }

        //// PUT api/<OrganizationsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OrganizationsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
