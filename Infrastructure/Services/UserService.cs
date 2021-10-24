using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Contracts.Data;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Application.DTO.Results;
using Core.Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly BRMContext _brmContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(BRMContext brmContext,
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

 

        public async Task<List<UserDTO>> GetAllUsersAsync(Guid mainUserId)
        {
            List<ApplicationUser> usersResult = new List<ApplicationUser>();
            var userCompany = await _userManager
                .FindByIdAsync(mainUserId.ToString());

            if (userCompany.OrganizationId != null)
            {
                usersResult = _userManager.Users
                    .Where(u=> u.OrganizationId == userCompany.OrganizationId)
                    .ToList();
            }
            var users = _mapper.Map<List<UserDTO>>(usersResult);
            return users;
        }

        public async Task<UserUpdatedResult> UpdateUserAsync(UserDTO user)
        {

            var userToUpdate = await _userManager.FindByIdAsync(user.Id.ToString());
            userToUpdate.Identification = user.Identification;
            userToUpdate.LastName = user.LastName;
            userToUpdate.SecondName = user.SecondName;
            userToUpdate.UserName = user.UserName;
            userToUpdate.DepartmentId = user.DepartmentId;
            userToUpdate.Email = user.Email;
            userToUpdate.FirstName = user.FirstName;
            

            //var userToUpdate = _mapper.Map<ApplicationUser>(user);
            var result = await _userManager.UpdateAsync(userToUpdate);
            //userToUpdate.DepartmentId = user.DepartmentId;
            //_brmContext.Update(userToUpdate);
            //var result = _brmContext.SaveChanges();

            return new UserUpdatedResult { Sussess = result.Succeeded };
        }
    }
}
