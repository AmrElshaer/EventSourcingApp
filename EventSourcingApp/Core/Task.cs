using EventSourcingApp.Core.Events;

namespace EventSourcingApp.Core
{
    public record Task : BaseAggregateRoot<Task, Guid>
    {
        public string Title { get; private set; }
        public BoardSections Section { get; private set; }
        public string AssignedTo { get; private set; }
        public bool IsCompleted { get; private set; }
        private Task() { }

        public Task(Guid taskId, string title, string createdBy) : base(taskId)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));
            if (createdBy == null)
                throw new ArgumentNullException(nameof(createdBy));

            this.Append(new CreatedTask(this, title, createdBy));
        }
        protected override void When(IDomainEvent<Guid> @event)
        {
            switch (@event)
            {
                case CreatedTask x: OnCreated(x); break;
                case AssignedTask x: OnAssigned(x); break;
                case MovedTask x: OnMoved(x); break;
                case CompletedTask x: OnCompleted(x); break;
            }
        }
        public void Complete(string completedBy)
        {
            if (Version == -1)
            {
                throw new TaskNotFoundException();
            }

            if (IsCompleted)
            {
                throw new TaskCompletedException();
            }

            this.Append(new CompletedTask(this, completedBy));
        }
        private void OnCompleted(CompletedTask @event)
        {
            IsCompleted = true;
        }
        public void Create(string title, string createdBy)
        {
            if (Version >= 0)
            {
                throw new TaskAlreadyCreatedException();
            }
            this.Append(new CreatedTask(this, title, createdBy));
        }
        private void OnCreated(CreatedTask @event)
        {
            Section = BoardSections.Open;
        }
        public void Assign(string assignedTo, string assignedBy)
        {
            if (Version == -1)
            {
                throw new TaskNotFoundException();
            }

            if (IsCompleted)
            {
                throw new TaskCompletedException();
            }

            this.Append(new AssignedTask(this, assignedBy, assignedTo));
        }
        private void OnAssigned(AssignedTask @event)
        {
            AssignedTo = @event.AssignedTo;
        }
        public void Move(BoardSections section, string movedBy)
        {
            if (Version == -1)
            {
                throw new TaskNotFoundException();
            }

            if (IsCompleted)
            {
                throw new TaskCompletedException();
            }

            this.Append(new MovedTask
            (
                this, movedBy, section
            ));
        }
        private void OnMoved(MovedTask @event)
        {
            Section = @event.Section;
        }

    }
}
