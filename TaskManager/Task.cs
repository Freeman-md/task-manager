using System;
namespace TaskManager
{
	public class Task
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public DateTime Deadline { get; set; }

        public Task(string title, string description, TaskPriority taskPriority = TaskPriority.MEDIUM, DateTime? deadline = null)
        {
            Title = title;
            Description = description;
            TaskPriority = taskPriority;
            Deadline = deadline ?? DateTime.Now;
        }

        public void ToConsole()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Title: {Title}");
            Console.ResetColor();
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Priority: {TaskPriority}");
            Console.WriteLine($"Deadline: {Deadline.ToShortDateString()}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================\n");
            Console.ResetColor();
        }
    }
}

