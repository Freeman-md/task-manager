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
    }
}

