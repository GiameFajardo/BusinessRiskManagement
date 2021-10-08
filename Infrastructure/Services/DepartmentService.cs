using AutoMapper;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly BRMContext _brmContext;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly Guid _organizationId;
        public DepartmentService(
            BRMContext brmContext,
            IMapper mapper,
            IIdentityService identityService)
        {
            this._brmContext = brmContext;
            this._mapper = mapper;
            this._identityService = identityService;
            _organizationId = _identityService.GetOrganizationContext();
        }
        public DepartmentDTO CreateDepartment(DepartmentDTO department)
        {
            if (department.OrganizacionId == Guid.Empty)
            {
                return null;
            }
            if (department.FatherDepartmentId == Guid.Empty)
            {
                department.FatherDepartmentId = null;
            }
            var departmentToCreate = _mapper.Map<Department>(department);
            departmentToCreate.Id = Guid.NewGuid();
            var result = _brmContext.Departments.Add(departmentToCreate);
            _brmContext.SaveChanges();
            return _mapper.Map<DepartmentDTO>(result.Entity);

        }

        public Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentDTO> GetAll(Guid organizationId)
        {
            var departments = _brmContext.Departments
                .Where(d => d.OrganizacionId == organizationId).ToList();
            var departmentsToReturn = _mapper.Map<List<DepartmentDTO>>(departments);
            _brmContext.SaveChanges();
            return departmentsToReturn;
        }

        public Task<List<DepartmentDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
