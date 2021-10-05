using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO user);
        Task<UserCreationResult> CreateUserAsync(UserDTO user, Guid userCompanyId);
    }
}
