using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ToDoList
{
    public class ToDoList
    {
        private List<ToDoTask> tasks = new List<ToDoTask>();
        private const string FilePath = "tasks.json";

        public List<ToDoTask> GetSortedTasks()
        {
            return tasks.OrderBy(t => t.Priority).ToList();
        }

        public void AddTask(ToDoTask task)
        {
            tasks.Add(task);
            SaveTasks();
        }

        public void DisplayTasks()
        {
            var sortedTasks = GetSortedTasks();

            if (sortedTasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            for (int i = 0; i < sortedTasks.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {sortedTasks[i].Description} - " +
                    $"{(sortedTasks[i].IsComplete ? "Complete" : "Incomplete")} - " +
                    $"(Priority: {sortedTasks[i].Priority})");
            }
        }

        public void CompleteTaskBySortedIndex(int sortedIndex)
        {
            var sortedTasks = GetSortedTasks();

            if (sortedIndex >= 0 && sortedIndex < sortedTasks.Count)
            {
                sortedTasks[sortedIndex].CompleteTask();
                SaveTasks();
            }
        }

        public void RemoveTaskBySortedIndex(int sortedIndex)
        {
            var sortedTasks = GetSortedTasks();

            if (sortedIndex >= 0 && sortedIndex < sortedTasks.Count)
            {
                var taskToRemove = sortedTasks[sortedIndex];
                tasks.Remove(taskToRemove);
                SaveTasks();
            }
        }

        public void EditTaskBySortedIndex(int sortedIndex, string newDescription, int newPriority)
        {
            var sortedTasks = GetSortedTasks();

            if (sortedIndex >= 0 && sortedIndex < sortedTasks.Count)
            {
                sortedTasks[sortedIndex].Description = newDescription;
                sortedTasks[sortedIndex].Priority = newPriority;
                SaveTasks();
            }
        }

        public void SaveTasks()
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }

        public void LoadTasks()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                tasks = JsonSerializer.Deserialize<List<ToDoTask>>(json) ?? new List<ToDoTask>();
            }
        }
    }
}