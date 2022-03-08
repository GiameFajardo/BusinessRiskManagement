using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Data
{
    public interface IStorageConnectionFactory
    {
        Task<CloudBlobContainer> OrganizationPhotoContainer();
    }
}
