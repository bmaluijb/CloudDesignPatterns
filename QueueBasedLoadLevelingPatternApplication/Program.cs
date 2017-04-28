using QueueBasedLoadLevelingPatternLibary;
using System;
using System.Threading;

namespace QueueBasedLoadLevelingPatternApplication
{
    class Program
    {
        private static Random _random = new Random();
        private static QueueService _queueService = new QueueService();

        static void Main(string[] args)
        {
            Console.WriteLine("Press key to start...");
            Console.ReadLine();

            do
            {
                var message = "new message " + _random.Next();
                _queueService.QueueNewMessage(message);

                Console.WriteLine(DateTime.Now.ToLongTimeString() + " " + message);

                Thread.Sleep(2000);

            } while (true);
        }
    }
}
