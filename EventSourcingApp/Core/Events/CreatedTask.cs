namespace EventSourcingApp.Core.Events
{
    public record CreatedTask : BaseDomainEvent<Task, Guid>
    {
        public CreatedTask(Task task, string title, string creatBy) : base(task)
        {
            this.CreatedBy = creatBy;
            this.Title = title;
        }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
    }
}
