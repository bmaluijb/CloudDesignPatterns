using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.Configuration;

namespace QueueBasedLoadLevelingPatternLibary
{
    public class QueueService    {

        private CloudStorageAccount _storageAccount;

        public QueueService()
        {
            //get the azure storage connectionstring from config. If it doesnt exist, this will throw an exception
            var connectionString = 
                ConfigurationManager.ConnectionStrings["AzureStorageConnectionString"].ConnectionString;

            _storageAccount = CloudStorageAccount.Parse(connectionString);
            
        }

        public void QueueNewMessage(string newMessage)
        {
            // Create the CloudQueueClient object for the storage account.
            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();

            // Get a reference to the CloudQueue named "NewQueue"
            CloudQueue newQueue = queueClient.GetQueueReference("newqueue");

            // Create the CloudQueue if it does not exist.
            newQueue.CreateIfNotExists();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(newMessage);
            newQueue.AddMessage(message);
        }



        public CloudQueueMessage PeekAtMessage()
        {
            // Create the CloudQueueClient object for the storage account.
            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();

            // Get a reference to the CloudQueue named "NewQueue"
            CloudQueue storeQueue = queueClient.GetQueueReference("newqueue");

            //Peek at the next message in the queue
            //Peeking does not hide the message
            return storeQueue.PeekMessage();             
        }

        public CloudQueueMessage GetMessage()
        {
            // Create the CloudQueueClient object for the storage account.
            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();

            // Get a reference to the CloudQueue named "NewQueue"
            CloudQueue storeQueue = queueClient.GetQueueReference("newqueue");

            //Gets the next message in the queue and sets it invisble
            //By default, it is invisible for other callers for 30 seconds
            return storeQueue.GetMessage();
        }

        public void DeleteMessage(CloudQueueMessage message)
        {
            // Create the CloudQueueClient object for the storage account.
            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();

            // Get a reference to the CloudQueue named "NewQueue"
            CloudQueue storeQueue = queueClient.GetQueueReference("newqueue");

            //Deletes the message from the queue
            storeQueue.DeleteMessage(message);
        }
    }
}
