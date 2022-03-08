using Core.Application.Contracts.Data;
using Core.Application.Contracts.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AzureStorage : ICloudStorage
    {

        private CloudBlobContainer ContainerSelected;
        private AzureContainer _container;
        private readonly IStorageConnectionFactory _storageConnectionFactory;

        public AzureContainer Container
        {
            get { return _container; }
            set
            {
                _container = value;
            }
        }
        public AzureStorage(IStorageConnectionFactory storageConnectionFactory)
        {
            this._storageConnectionFactory = storageConnectionFactory;
        }
        public async Task DeleteImageAsync(string name)
        {
            Uri uri = new Uri(name);
            string filename = Path.GetFileName(name);
            var blobContainer = ContainerSelected;
            var blob = blobContainer.GetBlockBlobReference(filename);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<CloudBlob> FindBlob(string fileName)
        {
            var blobContainer = ContainerSelected;
            var blob = blobContainer.GetBlobReference(fileName);
            var d = blob.ExistsAsync();
            return blob;
        }

        public async Task SetContainerAsync(AzureContainer container)
        {
            if (container == AzureContainer.OrganizationPhoto)
            {
                ContainerSelected = await _storageConnectionFactory.OrganizationPhotoContainer();
            }
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var blobContainer = ContainerSelected;

            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(GetRandomBlobName(file.FileName));
            using (var stream = file.OpenReadStream())
            {
                await blob.UploadFromStreamAsync(stream);
            }
            return blob.Uri.AbsoluteUri;
        }

        public async Task<string> UploadAsync(MemoryStream stream, string fileName)
        {
            var blobContainer = ContainerSelected;

            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);
            using (stream)
            {
                await blob.UploadFromStreamAsync(stream);
            }
            return blob.Uri.AbsoluteUri;
        }
        private string GetRandomBlobName(string filename)
        {
            string ext = Path.GetExtension(filename);
            if (string.IsNullOrEmpty(ext))
            {
                ext = ".jpg";
            }
            return string.Format("{0:10}_{1}{2}", DateTime.Now.Ticks, Guid.NewGuid(), ext);
        }
    }
}
