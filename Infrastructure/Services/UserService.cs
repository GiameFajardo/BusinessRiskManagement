﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IBRMContext _brmContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(IBRMContext brmContext,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            this._brmContext = brmContext;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }


        public async Task<UserCreationResult> CreateUserAsync(UserDTO user, Guid userCompanyId)
        {
            var userCompany = await _userManager.FindByIdAsync(userCompanyId.ToString());

            var userToCreate = _mapper.Map<ApplicationUser>(user);
            userToCreate.OrganizationId = userCompany.OrganizationId;
            userToCreate.Id = Guid.NewGuid().ToString();
            var userCreated = await _userManager.CreateAsync(userToCreate);

            if (!userCreated.Succeeded)
            {
                return new UserCreationResult { Sussess = false, Errors = userCreated.Errors.Select(e => e.Description) };
            }
            var userResult = _mapper.Map<UserDTO>(userToCreate);
            var result = new UserCreationResult { Sussess = true, User = userResult };

            return result;
        }

 

        public List<UserDTO> GetAllUsers()
        {
            var usersResult = _userManager.Users.ToList();
            var users = _mapper.Map<List<UserDTO>>(usersResult);
            return users;
        }

    }
}
