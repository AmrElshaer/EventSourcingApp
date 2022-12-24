namespace EventSourcingApp.Core.Events
{
    public record MovedTask : BaseDomainEvent<Task, Guid>
    {
        public MovedTask(Task task, string movedBy, BoardSections boardSections) : base(task)
        {
            this.MovedBy = movedBy;
            this.Section = boardSections;
        }
        public string MovedBy { get; set; }
        public BoardSections Section { get; set; }
    }
}
