using AutoMapper;
using BusinessRiskManagement.Requests;
using BusinessRiskManagement.Responses;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest request)
        {
            var userCompany = HttpContext.User.Claims.SingleOrDefault(c => c.Type == "id").Value;
            var userToCreate = _mapper.Map<UserDTO>(request);

            var userCreated = await _userService.CreateUserAsync(userToCreate, new Guid(userCompany));
            var userResponse = _mapper.Map<UserResponse>(userCreated.User);
            return userResponse;
        }
        [HttpPatch("update")]
        public async Task<ActionResult<UserResponse>> Update(UpdateUserRequest user)
        {

            var userToUpdate = _mapper.Map<UserDTO>(user);

            var userCreated = await _userService.UpdateUserAsync(userToUpdate);
            var userResponse = _mapper.Map<UserResponse>(userCreated.User);
            return userResponse;
        }
        [HttpGet("list")]
        public async Task<ActionResult<List<UserResponse>>> GetAll()
        {
            var userCompany = HttpContext.User.Claims.SingleOrDefault(c => c.Type == "id").Value;

            var userResult = await _userService.GetAllUsersAsync(new Guid(userCompany));
            var users = userResult.Select(u => _mapper.Map<UserResponse>(u)).ToList();
            return users;
        }
    }
}
