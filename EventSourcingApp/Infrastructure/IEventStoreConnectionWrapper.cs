using EventStore.ClientAPI;

namespace EventSourcingApp.Infrastructure
{
    public interface IEventStoreConnectionWrapper
    {
        Task<IEventStoreConnection> GetConnectionAsync();
    }
}