namespace EventSourcingApp.Core.Events
{
    public record AssignedTask : BaseDomainEvent<Task, Guid>
    {
        public AssignedTask(Task task, string assignedBy, string assignedTo) : base(task)
        { this.AssignedBy = assignedBy; this.AssignedTo = assignedTo; }

        public Guid TaskId { get; set; }
        public string AssignedBy { get; set; }
        public string AssignedTo { get; set; }
    }
}
