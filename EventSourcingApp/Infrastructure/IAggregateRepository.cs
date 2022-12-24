using EventSourcingApp.Core;

namespace EventSourcingApp.Infrastructure
{
    public interface IAggregateRepository<TA, TKey>
      where TA : class, IAggregateRoot<TKey>
    {
        System.Threading.Tasks.Task PersistAsync(TA aggregateRoot, CancellationToken cancellationToken = default);
        Task<TA> RehydrateAsync(TKey key, CancellationToken cancellationToken = default);
    }
}
