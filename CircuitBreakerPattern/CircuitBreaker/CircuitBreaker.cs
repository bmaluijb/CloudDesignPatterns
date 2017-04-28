using System;

namespace CircuitBreakerPattern
{
    public class CircuitBreaker
    {
        private readonly ICircuitBreakerStateStore stateStore 
            = new CircuitBreakerStateStore();

        //The time that the breaker should remain open, 
        //before testing it in the halfopen state
        private TimeSpan OpenTimeOutTime = new TimeSpan(0, 0, 10);
        
        public void ExecuteAction(Action action)
        {
            if (!stateStore.IsClosed)
            {
                //The circuit breaker is open. Test if the timeout is elapsed
                //This is a very simple check. You could do more complex tests to put the 
                //circuit breaker in the halfopen state
                if (stateStore.LastChangedDateUtc + OpenTimeOutTime < DateTime.UtcNow)
                {
                    //The timeout has expired, so allow the action to be executed
                    //This tests if the external service is up and running again
                    //You could do more complex tests
                    try
                    {
                        stateStore.HalfOpen();

                        //Try the call
                        action();

                        //If the call succeeded, we assume that the external service 
                        //is up and running so we rest the circuit breaker to the closed state
                        stateStore.Reset();
                        return;
                    }
                    catch (Exception ex)
                    {
                        //The call didn't succeed, so the service is not working yet
                        //Thereofre, trip the circuit breaker again, setting a new exception 
                        //and putting it in the open state
                        stateStore.Trip(ex);
                        
                        throw;
                    }
                }

                //The timout hasn't elapsed yet, so the call is not made.
                //Let the caller know by returning a CircuitBreakerOpenException
                throw new CircuitBreakerOpenException(stateStore.LastException);
            }

            //The circuit breaker is closed, call the external service
            try
            {
                action();
            }
            catch (Exception ex)
            {
                //The call didn't succeed, trip the circuit breaker
                TrackException(ex);

                //Throw the exception so that the caller can tell
                //the type of exception that was thrown.
                throw;
            }
        }

        private void TrackException(Exception ex)
        {
            //This is a very simple example. The circuit breaker trips on the first exception, 
            //without any additional checks. You can make this more robust by tripping the
            //circuit breaker after a set number of failures or after another test
            stateStore.Trip(ex);
        }
    }

}
