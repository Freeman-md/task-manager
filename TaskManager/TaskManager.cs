using System;
using System.Collections.Generic;

namespace TaskManager
{
	public class TaskManager
	{
        private static List<Task> tasks = new List<Task>();

		public TaskManager()
		{
		}

		public static void CreateTask()
		{
            string title = Utilities.GetValidInput("Enter the task title: ");
            string description = Utilities.GetValidInput("Enter the task description: ");
            TaskPriority priority = Utilities.GetValidEnum<TaskPriority>("Enter the task priority (high, medium, low): ");
            DateTime deadline = Utilities.GetValidDateTime("Enter the task deadline (YYYY-MM-DD): ");
			try
			{

                Task task = new Task(title, description, priority, deadline);
                tasks.Add(task);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task created successfully.");
                Console.ResetColor();
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error creating task: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}

