namespace EventSourcingApp.Core
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
