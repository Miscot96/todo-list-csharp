using System;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();
            toDoList.LoadTasks();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== To-Do List App ===");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Complete task");
                Console.WriteLine("3. Display all tasks");
                Console.WriteLine("4. Edit task");
                Console.WriteLine("5. Remove task");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTaskFlow(toDoList);
                        break;

                    case "2":
                        CompleteTaskFlow(toDoList);
                        break;

                    case "3":
                        ShowTasksFlow(toDoList);
                        break;

                    case "4":
                        EditTaskFlow(toDoList);
                        break;

                    case "5":
                        RemoveTaskFlow(toDoList);
                        break;

                    case "6":
                        Console.WriteLine("Tasks saved. Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Pause();
                        break;
                }
            }
        }

        static void AddTaskFlow(ToDoList toDoList)
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine() ?? string.Empty;

            int priority = ReadInt("Enter task priority: ");

            toDoList.AddTask(new ToDoTask(description, priority));

            Console.WriteLine("Task added.");
            Pause();
        }

        static void CompleteTaskFlow(ToDoList toDoList)
        {
            Console.WriteLine("Here is a list of all your tasks:");
            toDoList.DisplayTasks();
            Pause();

            int taskNumber = ReadInt("Enter task number to complete: ");
            toDoList.CompleteTaskBySortedIndex(taskNumber - 1);

            Console.WriteLine("Task completed.");
            Pause();
        }

        static void ShowTasksFlow(ToDoList toDoList)
        {
            Console.WriteLine("Here is a list of all your tasks:");
            toDoList.DisplayTasks();
            Pause();
        }

        static void EditTaskFlow(ToDoList toDoList)
        {
            Console.WriteLine("Here is a list of all your tasks:");
            toDoList.DisplayTasks();
            Pause();

            int taskNumber = ReadInt("Enter task number to edit: ");

            Console.Write("Enter new task description: ");
            string newDescription = Console.ReadLine() ?? string.Empty;

            int newPriority = ReadInt("Enter new task priority: ");

            toDoList.EditTaskBySortedIndex(taskNumber - 1, newDescription, newPriority);

            Console.WriteLine("Task updated.");
            Pause();
        }

        static void RemoveTaskFlow(ToDoList toDoList)
        {
            Console.WriteLine("Here is a list of all your tasks:");
            toDoList.DisplayTasks();
            Pause();

            int taskNumber = ReadInt("Enter task number to delete: ");
            toDoList.RemoveTaskBySortedIndex(taskNumber - 1);

            Console.WriteLine("Task removed.");
            Pause();
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    return number;
                }

                Console.WriteLine("Invalid number. Please try again.");
            }
        }

        static void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}