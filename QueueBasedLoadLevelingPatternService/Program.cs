using Microsoft.WindowsAzure.Storage.Queue;
using QueueBasedLoadLevelingPatternLibary;
using System;
using System.Threading;

namespace QueueBasedLoadLevelingPatternService
{
    class Program
    {

        private static QueueService _queueService = new QueueService();

        static void Main(string[] args)
        {
            Console.WriteLine("Press key to start...");
            Console.ReadLine();

            do
            {
                CloudQueueMessage peekedMessage = _queueService.PeekAtMessage();

                if (peekedMessage == null)
                {
                    break;
                   


                }

                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Peeked at: " + peekedMessage.AsString);

                CloudQueueMessage message = _queueService.GetMessage();

                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Got message: " + message.AsString);
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Processing message..");
                _queueService.DeleteMessage(message);

                Thread.Sleep(1000);

            } while (true);

            Console.WriteLine(DateTime.Now.ToLongTimeString() + " No messages in the queue!");
            Console.ReadLine();
        }
    }
}
