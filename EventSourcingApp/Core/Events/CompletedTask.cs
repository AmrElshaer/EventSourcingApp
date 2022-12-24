namespace EventSourcingApp.Core.Events
{
    public record CompletedTask : BaseDomainEvent<Task, Guid>
    {
        public CompletedTask(Task task, string completedBy) : base(task)
        {
            this.CompletedBy = completedBy;
        }
        public string CompletedBy { get; set; }
    }
}
