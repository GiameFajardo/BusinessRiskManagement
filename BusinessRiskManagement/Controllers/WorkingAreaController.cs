using AutoMapper;
using BusinessRiskManagement.Requests;
using BusinessRiskManagement.Responses.WorkingArea;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class WorkingAreaController : Controller
    {
        private readonly IWorkingAreaService _workingAreaService;
        private readonly IMapper _mapper;

        public WorkingAreaController(
            IWorkingAreaService workingAreaService,
            IMapper mapper)
        {
            this._workingAreaService = workingAreaService;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        public ActionResult<WorkingAreaResult> Get()
        {

            var orgId = HttpContext.User.Claims
                .SingleOrDefault(c => c.Type == "companyId").Value;
            var result = _workingAreaService.GetAll(new Guid(orgId));
            var waToReturn = _mapper.Map<List<WorkingAreaResponse>>(result);
            var response = new WorkingAreaResult { Result = waToReturn };
            return Ok(response);
        }
        [HttpPost("create")]
        public async Task<ActionResult<WorkingAreaResponse>> Create([FromBody] CreateWorkingAreaRequest request)
        {
            var orgId = HttpContext.User.Claims
                .SingleOrDefault(c => c.Type == "companyId").Value;
            var waToCreate = _mapper.Map<WorkinAreaDTO>(request);
            //waToCreate.OrganizacionId = new Guid(orgId);
            var waCreated = _workingAreaService
                .CreateWorkingArea(waToCreate);
            var waResponse = _mapper.Map<WorkingAreaResponse>(waCreated);
            return waResponse;
        }
    }
}
