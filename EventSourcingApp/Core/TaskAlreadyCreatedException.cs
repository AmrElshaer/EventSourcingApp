namespace EventSourcingApp.Core
{
    public class TaskAlreadyCreatedException : Exception
    {
        public TaskAlreadyCreatedException() : base("Task already created.") { }
    }
}
