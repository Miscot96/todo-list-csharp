namespace ToDoList
{
    public class ToDoTask
    {
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public int Priority { get; set; }

        public ToDoTask()
        {
        }

        public ToDoTask(string description, int priority)
        {
            Description = description;
            IsComplete = false;
            Priority = priority;
        }

        public void CompleteTask()
        {
            IsComplete = true;
        }
    }
}