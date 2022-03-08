using Core.Application.Contracts.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Data
{

    public interface ICloudStorage
    {
        Task SetContainerAsync(AzureContainer container);
        Task<string> UploadAsync(IFormFile file);
        Task<string> UploadAsync(MemoryStream stream, string fileName);
        Task DeleteImageAsync(string name);
        // Si se requiere desacoplar Azure de esta implementacion este metodo hay que cambiarlo
        Task<CloudBlob> FindBlob(string fileName);
    }
}
