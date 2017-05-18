using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using System;

namespace EventSourcingPattern
{
    /// <summary>
    /// I'm using NEventStore
    /// https://github.com/NEventStore/NEventStore
    /// </summary>
    public class EventStore : IDisposable
    {
        private IStoreEvents _store;

        public EventStore()
        {
            _store = Wireup.Init()
              //uncomment these lines to enable SQL Server as a datastore
              //Also, put your SQL Server connectionstring in App.config

              //.UsingSqlPersistence("SqlConnectionString")
              //.WithDialect(new MsSqlDialect())

              //comment when using another datastore
              .UsingInMemoryPersistence()
              .InitializeStorageEngine()
              .UsingJsonSerialization()
              .Build();
        }

        /// <summary>
        /// Write a new event to the event store
        /// </summary>
        /// <param name="streamId"></param>
        /// <param name="command"></param>
        public void AppendToStream(Guid streamId, Command command)
        {
            using (IEventStream stream = _store.OpenStream(streamId, 0, int.MaxValue))
            {
                stream.Add(new EventMessage { Body = command });
                stream.CommitChanges(command.EventId);
            }
        }


        /// <summary>
        /// Replay the events in the event store (by the current stream Id)
        /// and count and retun the amount
        /// </summary>
        /// <param name="streamId"></param>
        /// <returns></returns>
        public double GetAmount(Guid streamId)
        {
            double result = 0;

            using (var stream = _store.OpenStream(streamId, 0, int.MaxValue))
            {
                //read the event as a dynamic type so that we don't have to explicitely
                //cast to CashDepositCommand or CashWithdrawalCommand
                foreach (dynamic item in stream.CommittedEvents)
                {
                    result+= item.Body.Amount;
                }
            }

            return result;
        }

        public void Dispose()
        {
            _store.Dispose();
        }
    }
}
