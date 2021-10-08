using AutoMapper;
using BusinessRiskManagement.Requests;
using BusinessRiskManagement.Responses;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(
            IMapper mapper,
            IDepartmentService departmentService)
        {
            this._mapper = mapper;
            this._departmentService = departmentService;
        }

        [HttpGet("list")]
        public ActionResult<List<DepartmentResponse>> Get()
        {

            var orgId = HttpContext.User.Claims
                .SingleOrDefault(c => c.Type == "companyId").Value;
            var departments = _departmentService.GetAll(new Guid(orgId));
            var departmentToReturn = _mapper.Map<List<DepartmentResponse>>(departments);
            return Ok(departmentToReturn);
        }
        [HttpPost("create")]
        public async Task<ActionResult<DepartmentResponse>> Create([FromBody] CreateDepartmentRequest request)
        {
            var orgId = HttpContext.User.Claims
                .SingleOrDefault(c => c.Type == "companyId").Value;
            var departmentToCreate = _mapper.Map<DepartmentDTO>(request);
            departmentToCreate.OrganizacionId = new Guid(orgId);
            var departmentCreated = _departmentService
                .CreateDepartment(departmentToCreate);
            var departmentResponse = _mapper.Map<DepartmentResponse>(departmentCreated);
            return departmentResponse;
        }
    }
}
