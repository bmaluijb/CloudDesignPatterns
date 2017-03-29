using System;
using System.Runtime.Serialization;

namespace CircuitBreakerPattern
{
    [Serializable]
    internal class CircuitBreakerOpenException : Exception
    {
        

        public CircuitBreakerOpenException()
        {
        }

        public CircuitBreakerOpenException(Exception lastException) 
            : base("Method not called", lastException)
        {
            
        }

        public CircuitBreakerOpenException(string message) 
            : base(message)
        {
        }

        public CircuitBreakerOpenException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected CircuitBreakerOpenException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}