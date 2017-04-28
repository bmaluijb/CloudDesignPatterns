using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageService storageService = new StorageService();

            do
            {

                string result = storageService.ReadWriteToStorage();

                Console.WriteLine(result);

                Console.ReadLine();

            } while (true);
        }
    }
}
