using Core.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IWorkingAreaService
    {
        WorkinAreaDTO CreateWorkingArea(WorkinAreaDTO wa);
        List<WorkinAreaDTO> GetAll(Guid organizationId);

        List<WorkinAreaDTO> GetAllByUser(Guid organizationId, Guid UserId);
    }
}
