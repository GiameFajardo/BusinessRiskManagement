using AutoMapper;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly BRMContext _brmContext;
        private readonly IMapper _mapper;

        public DepartmentService(BRMContext brmContext, IMapper mapper)
        {
            this._brmContext = brmContext;
            this._mapper = mapper;
        }
        public DepartmentDTO CreateDepartment(DepartmentDTO department)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
