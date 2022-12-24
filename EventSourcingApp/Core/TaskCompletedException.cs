namespace EventSourcingApp.Core
{
    public class TaskCompletedException : Exception
    {
        public TaskCompletedException() : base("Task is completed.") { }
    }
}
