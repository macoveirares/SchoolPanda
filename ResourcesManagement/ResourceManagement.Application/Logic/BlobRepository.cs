using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ResourceManagement.Application.Logic
{
    #region Blob reference

    public interface IBlobReference
    {
        string BlobContainer { get; }
        string ConnectionStringConfigName { get; }
        string StorageUrl { get; }
    }

    public class ResourceReference : IBlobReference
    {
        public string BlobContainer
            => "webservice";

        public string ConnectionStringConfigName
            => "StorageConnectionString";

        public string StorageUrl
            => "https://cloudxdbstoragestaging.blob.core.windows.net/webservice/";
        
    }

    #endregion

    public interface IBlobRepository<T>
    {
        void UploadBytes(byte[] bytes, string path);
        void UploadContent(string path, string content);
        string DownloadText(string path);
        string GetUrlByName(string name);
    }

    public class BlobRepository<T> : IBlobRepository<T> where T : IBlobReference, new()
    {
        private readonly CloudBlobContainer _blobContainer;
        private readonly Microsoft.WindowsAzure.Storage.CloudStorageAccount _storageAccount;
        private readonly IConfiguration _configuration;

        public BlobRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _storageAccount = GetStorageAccount(new T().ConnectionStringConfigName);
            _blobContainer = GetBlobContainer(_storageAccount);
        }

        public void UploadBytes(byte[] bytes, string path)
            => _blobContainer.GetBlockBlobReference(path)
                .UploadFromByteArrayAsync(bytes, 0, bytes.Count());

        public void UploadContent(string path, string content)
            => _blobContainer.GetBlockBlobReference(path).UploadTextAsync(content);

        public string DownloadText(string path)
            => _blobContainer.GetBlockBlobReference(path).DownloadTextAsync().Result;

        public string GetUrlByName(string name)
        {
            var blob = _blobContainer.GetBlockBlobReference(name);
            return blob.Uri.AbsoluteUri;
        }

        #region statics

        private Microsoft.WindowsAzure.Storage.CloudStorageAccount GetStorageAccount(string connectionString)
        {
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(
               _configuration["Storage:ConnectionString"]);

            Debug.Assert(storageAccount != null, "Culdn't connect to Storage Account");
            return storageAccount;
        }

        private static CloudBlobContainer GetBlobContainer(Microsoft.WindowsAzure.Storage.CloudStorageAccount storageAccount)
        {
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(new T().BlobContainer.ToString());
            container.CreateIfNotExistsAsync();
            container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            return container;
        }

        #endregion
    }
}