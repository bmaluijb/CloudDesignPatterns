using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;
using System.Configuration;

namespace RetryPattern
{

    /// <summary>
    /// Retry guidance: 
    /// https://docs.microsoft.com/en-us/azure/architecture/best-practices/retry-service-specific 
    /// </summary>
    public class StorageService
    {
        private CloudStorageAccount _storageAccount;

        public StorageService()
        {

            //get the azure storage connectionstring from config. If it doesnt exist, this will throw an exception
            var connectionString =
                ConfigurationManager.ConnectionStrings["AzureStorageConnectionString"].ConnectionString;

            _storageAccount = CloudStorageAccount.Parse(connectionString);
        }

        public string  ReadWriteToStorage()
        {
            CloudBlobClient blobClient = CreateBlobClient();

            CloudBlobContainer newContainer = blobClient.GetContainerReference("newcontainer");

            newContainer.CreateIfNotExists();

            CloudBlockBlob myNewBlob = newContainer.GetBlockBlobReference("mynewblob");

            if (!myNewBlob.Exists())
            {
                myNewBlob.UploadText("This is the text that the Blob contains...");
            }

            return myNewBlob.DownloadText();
        }

        private CloudBlobClient CreateBlobClient()
        { 
            CloudBlobClient client = _storageAccount.CreateCloudBlobClient();
            client.DefaultRequestOptions = new BlobRequestOptions
            {
                RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(3), 4),

                LocationMode = LocationMode.PrimaryThenSecondary,

                MaximumExecutionTime = TimeSpan.FromSeconds(20)
            };

            return client;
        }
    }
}
