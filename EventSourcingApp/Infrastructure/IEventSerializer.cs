using EventSourcingApp.Core;

namespace EventSourcingApp.Infrastructure
{
    public interface IEventSerializer
    {
        IDomainEvent<TKey> Deserialize<TKey>(string type, byte[] data);
        IDomainEvent<TKey> Deserialize<TKey>(string type, string data);
        byte[] Serialize<TKey>(IDomainEvent<TKey> @event);
    }
}
