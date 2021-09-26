using Core.Application.Contracts.Data;
using Infrastructure.DTO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StorageConnectionFactory : IStorageConnectionFactory
    {
        private readonly CloudStorageOptionsDTO _storageOptions;

        private CloudBlobClient blobClient;
        private CloudBlobContainer blobContainer;
        public StorageConnectionFactory(CloudStorageOptionsDTO storageOptions)
        {
            this._storageOptions = storageOptions;
        }
        public async Task<CloudBlobContainer> OrganizationPhotoContainer()
        {
            if (blobContainer != null)
            {
                return blobContainer;
            }
            CloudStorageAccount storageAccount = CloudStorageAccount
                            .Parse(_storageOptions.ConnectionString);

            blobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference(_storageOptions.OrganizationPhotoContainer);
            await blobContainer.CreateIfNotExistsAsync();

            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return blobContainer;
        }
    }
}
