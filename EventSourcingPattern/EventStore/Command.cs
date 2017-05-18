using System;

namespace EventSourcingPattern
{
    public class Command
    {
        public Guid EventId { get; set; }
    }
}
