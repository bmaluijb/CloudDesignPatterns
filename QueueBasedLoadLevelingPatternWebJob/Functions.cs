using Microsoft.Azure.WebJobs;
using System;
using System.IO;

namespace QueueBasedLoadLevelingPatternWebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("newqueue")] string message, TextWriter log)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " Processing " + message);
        }
    }
}
