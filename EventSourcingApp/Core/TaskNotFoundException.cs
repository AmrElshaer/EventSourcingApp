namespace EventSourcingApp.Core
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() : base("Task not found.") { }
    }
}
