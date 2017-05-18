using System;

namespace EventSourcingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EventStore store = new EventStore())
            {
                //create a new streamID. This wil be used for partitioning
                Guid streamId = Guid.NewGuid();

                //create things that happened
                var depositevent1 = new CashDepositCommand { Amount = 100, EventId = Guid.NewGuid() };
                var depositevent2 = new CashDepositCommand { Amount = 20, EventId = Guid.NewGuid() };
                var withdrawalevent1 = new CashWithdrawalCommand { Amount = -75, EventId = Guid.NewGuid() };
                //100 + 20 - 75 = 45

                //commit those things
                store.AppendToStream(streamId, depositevent1);
                store.AppendToStream(streamId, depositevent2);
                store.AppendToStream(streamId, withdrawalevent1);

                //replay the events and get the current state of the data
                double stateOfData = store.GetAmount(streamId);

                Console.WriteLine("Balance: " + stateOfData);
                Console.ReadLine();
            }

        }
    }
}
