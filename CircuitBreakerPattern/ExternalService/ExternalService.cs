using System;

namespace CircuitBreakerPattern
{
    public class ExternalService
    {
        //Create a static random to improve the chance to get random numbers
        private static Random random = new Random();
        private static int failureCount = 0;

        public int CallMe()
        {        
            //Get a random number and try to devide it by 2.
            //If it is divisible by 2 and failurecount < 5, call failed
            int testNumber = random.Next();
            if (testNumber % 2 == 0 && failureCount < 5)
            {
                failureCount++;
                throw new Exception("I failed! Non-Transient Error " + testNumber);
            }
            
            failureCount = 0;
            return testNumber;
        }
    }
}
