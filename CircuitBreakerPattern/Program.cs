using System;

namespace CircuitBreakerPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var breaker = new CircuitBreaker();
            var service = new ExternalService();

            do
            {
                try
                {
                    breaker.ExecuteAction(() =>
                    {
                        // Call protected by the circuit breaker.
                        int result = service.CallMe();

                        //log the results
                        Console.WriteLine(DateTime.UtcNow.ToLongTimeString() 
                            + " CallMe succeeded " + result);
                    });
                }
                catch (CircuitBreakerOpenException ex)
                {
                    // The circuit breaker is open, so the call wasn't made                    
                    Console.WriteLine(DateTime.UtcNow.ToLongTimeString() 
                        + " CallMe not called " + ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    //The call was made and failed
                    Console.WriteLine(DateTime.UtcNow.ToLongTimeString() 
                        + " CallMe failed " + ex.Message);
                }

                Console.ReadLine();

            } while (true);
        }
    }
}
