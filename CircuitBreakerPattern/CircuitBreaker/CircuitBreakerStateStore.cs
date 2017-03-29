using System;

namespace CircuitBreakerPattern
{
    /// <summary>
    /// This class acts as an in-memory store for the state and additional
    /// information for the circuit breaker
    /// </summary>
    public class CircuitBreakerStateStore : ICircuitBreakerStateStore
    {
        public CircuitBreakerStateStore()
        {
            //set the default state of the circuit breaker state store
            State = CircuitBreakerStateEnum.Closed;
        }

        public CircuitBreakerStateEnum State { get; set; }

        public Exception LastException { get; set; }

        public DateTime LastChangedDateUtc { get; set; }

        public bool IsClosed
        {
            get
            {
                //the circuit breaker is closed when it is not Open or HalfOpen
                return (State == CircuitBreakerStateEnum.Closed);  
            }
            set { }
        }


        public void HalfOpen()
        {
            State = CircuitBreakerStateEnum.HalfOpen;
        }

        public void Reset()
        {
            State = CircuitBreakerStateEnum.Closed;
        }

        public void Trip(Exception ex)
        {
            //set to open and add additional info
            State = CircuitBreakerStateEnum.Open;
            LastException = ex;
            LastChangedDateUtc = DateTime.UtcNow;
        }
    }
}
