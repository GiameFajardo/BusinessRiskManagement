using AutoMapper;
using Core.Application.Contracts.Services;
using Core.Application.DTO;
using Core.Domain.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class WorkingAreaService : IWorkingAreaService
    {
        private readonly BRMContext _bmrContext;
        private readonly IMapper _mapper;

        public WorkingAreaService(BRMContext bmrContext, IMapper mapper)
        {
            this._bmrContext = bmrContext;
            this._mapper = mapper;
        }
        public WorkinAreaDTO CreateWorkingArea(WorkinAreaDTO wa)
        {
            var waToCreate = _mapper.Map<WorkingArea>(wa);
            var waCreated = _bmrContext.WorkingArea.Add(waToCreate);
            var saved = _bmrContext.SaveChanges();
            var waToReturn = _mapper.Map<WorkinAreaDTO>(waCreated.Entity);
            if (saved == 0)
            {
                return waToReturn;
            }
            else
            {
                return null;
            }
        }

        public List<WorkinAreaDTO> GetAll(Guid organizationId)
        {
            var wa = _bmrContext.WorkingArea
                .Include(wa => wa.WorkingAreaAssignations
                //.Select(a => a.ApplicationUser)
                )
                .ToList();
            var waToReturn = _mapper.Map<List<WorkinAreaDTO>>(wa);
            return waToReturn;
        }

        public List<WorkinAreaDTO> GetAllByUser(Guid organizationId, Guid UserId)
        {

            var wa = _bmrContext.WorkingArea
                .Include(wa => wa.WorkingAreaAssignations
                .Where(wa=>wa.ApplicationUserId == UserId.ToString())
                .Select(a => a.ApplicationUser))
                .ToList();
            var waToReturn = _mapper.Map<List<WorkinAreaDTO>>(wa);
            return waToReturn;
        }
    }
}
