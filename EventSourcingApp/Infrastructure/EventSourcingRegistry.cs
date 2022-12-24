using EventSourcingApp.Core;

namespace EventSourcingApp.Infrastructure
{
    public static class EventSourcingRegistry
    {
        public static IServiceCollection AddEventStore(this IServiceCollection services, string connectionString)
        {
            return services.AddSingleton<IEventStoreConnectionWrapper>(ctx =>
            {
                var logger = ctx.GetRequiredService<ILogger<EventStoreConnectionWrapper>>();
                return new EventStoreConnectionWrapper(new Uri(connectionString), logger);
            }).AddEventsRepository<Core.Task, Guid>();
        }

        private static IServiceCollection AddEventsRepository<TA, TK>(this IServiceCollection services)
            where TA : class, IAggregateRoot<TK>
        {
            return services.AddSingleton<IAggregateRepository<TA, TK>>(ctx =>
            {
                var connectionWrapper = ctx.GetRequiredService<IEventStoreConnectionWrapper>();
                var eventDeserializer = ctx.GetRequiredService<IEventSerializer>();
                return new AggregateRepository<TA, TK>(connectionWrapper, eventDeserializer);
            });
        }
    }
}
