using Core.Application.Contracts.Data;
using Core.Application.Contracts.Enum;
using Core.Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StorageService : IStorageService
    {
        private readonly ICloudStorage _cloudStorage;

        public StorageService(ICloudStorage cloudStorage
            )
        {
            this._cloudStorage = cloudStorage;
        }
        public Task<bool> ReplaceFile(IFormFile formFile, string filePath)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateOrganizationPhotoAsync(IFormFile formFile)
        {

            await _cloudStorage.SetContainerAsync(AzureContainer.OrganizationPhoto);
            var url = await _cloudStorage.UploadAsync(formFile);
            return url;
        }
    }
}
