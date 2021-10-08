using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IDepartmentService
    {
        DepartmentDTO CreateDepartment(DepartmentDTO department);
        Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department);
        List<DepartmentDTO> GetAll(Guid organizationId);
        Task<List<DepartmentDTO>> GetAllAsync();
    }
}
