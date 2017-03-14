using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System.Collections.Generic;
using ValetKeyPattern.Models;

namespace ValetKeyPattern.AzureStorage
{
    public class CORSConfigurator : ICORSConfigurator
    {
        private readonly ConnectionStrings _connectionStrings;

        public CORSConfigurator(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }
        public void EnableCORS()
        {
            var account = CloudStorageAccount.Parse(_connectionStrings.AzureStorageConnection);

            var blobClient = account.CreateCloudBlobClient();
     
            ServiceProperties blobServiceProperties = blobClient.GetServiceProperties();

            blobServiceProperties.Cors = new CorsProperties();

            blobServiceProperties.Cors.CorsRules.Add(new CorsRule()
            {                
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,                
                AllowedOrigins = new List<string>() { "*" },
                ExposedHeaders = new List<string>() { "*" },
                AllowedHeaders = new List<string>() { "*" },
                MaxAgeInSeconds = 600 
            });

            blobClient.SetServiceProperties(blobServiceProperties);
        }

    }
}
