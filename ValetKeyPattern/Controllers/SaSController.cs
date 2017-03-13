using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Globalization;
using ValetKeyPattern.AzureStorage;
using ValetKeyPattern.Models;

namespace ValetKeyPattern
{
    [Route("api/[controller]")]
    public class SaSController : Controller
    {
        private ICORSConfigurator _corsConfigurator;
        private readonly ConnectionStrings _connectionStrings;

        public SaSController(ICORSConfigurator corsConfigurator, IOptions<ConnectionStrings> connectionStrings)
        {
            _corsConfigurator = corsConfigurator;
            _corsConfigurator.EnableCORS();
            _connectionStrings = connectionStrings.Value;
        }

        // GET: api/getkey
        [HttpGet]
        public string GetKey(string blobName)
        {
             var account = CloudStorageAccount.Parse(_connectionStrings.AzureStorageConnection);

            var blobClient = account.CreateCloudBlobClient();
            
            var container = blobClient.GetContainerReference("pluralsightcontainer");
            container.CreateIfNotExists();

            // Get a blob reference
            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

            //Create a Shared Access Signature for the blob
            var SaS = blob.GetSharedAccessSignature(
               new SharedAccessBlobPolicy()
               {                   
                   Permissions = SharedAccessBlobPermissions.Write,
                   SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
               });

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri, SaS);
        }
    }
}
