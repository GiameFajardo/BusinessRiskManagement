using Core.Application.DTO;
using Core.Application.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync(Guid mainUserId);
        UserDTO CreateUser(UserDTO user);
        Task<UserCreationResult> CreateUserAsync(UserDTO user, Guid userCompanyId);

        Task<UserUpdatedResult> UpdateUserAsync(UserDTO user);
    }
}
