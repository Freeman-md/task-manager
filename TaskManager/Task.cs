using System.Text;

namespace TaskRepository
{
	public class Task
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime Deadline { get; set; }

        public Task()
        {
        }

        public Task(string title, string description, TaskPriority priority = TaskPriority.MEDIUM, DateTime? deadline = null)
        {
            Update(title, description, priority, deadline ?? DateTime.Now);
        }

        public void Update(string title, string description, TaskPriority priority, DateTime deadline)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Deadline = deadline;
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
            Console.WriteLine($"Priority: {Priority}");
            Console.WriteLine($"Deadline: {Deadline.ToShortDateString()}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================\n");
            Console.ResetColor();
        }

        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"title: {Title};");
            stringBuilder.Append($"description: {Description};");
            stringBuilder.Append($"priority: {Priority};");
            stringBuilder.Append($"deadline: {Deadline};");
            stringBuilder.Append(Environment.NewLine);

            return stringBuilder.ToString();
        }

    }
}

