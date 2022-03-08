using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Services
{
    public interface IStorageService
    {
        Task<string> UpdateOrganizationPhotoAsync(IFormFile formFile);

        Task<bool> ReplaceFile(IFormFile formFile, string filePath);
    }
}
