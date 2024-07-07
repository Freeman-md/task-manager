using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskRepository
{
	public class TaskRepository
    {
        private static string directory = @"/Users/freemancodz/Documents/TaskManager/";
        private static string fileName = "tasks.json";
        private static string path = $"{directory}{fileName}";
        private static List<Task> tasks = new List<Task>();

		public TaskRepository()
		{
		}

        private static Task FindTaskByTitle()
        {
            Task task;

            do
            {
                // Get task title user would like to edit
                string taskTitle = Utilities.GetValidInput("Enter the title of the task you want to edit: ").ToLower();

                // Find task by title
                task = tasks.Find(t => t.Title.ToLower().Contains(taskTitle));

                if (task == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Task with title '{taskTitle}' not found");
                    Console.ResetColor();
                }

            } while (task == null);

            return task;
        }

        public static void LoadTasks()
        {
            tasks = Utilities.LoadFromFile<List<Task>>(path);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {tasks.Count} task(s)");
            Console.ResetColor();
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
                Utilities.SaveToFile<List<Task>>(path, tasks);

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

        public static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    task.ToConsole();
                }
            }
        }

        public static void EditTask()
        {
            Task task = FindTaskByTitle();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Leave any field blank to keep the current value.");
            Console.ResetColor();

            string title = Utilities.GetValidInput($"Title (current: {task.Title}): ", task.Title);
            string description = Utilities.GetValidInput($"Description (current: {task.Description}): ", task.Description);
            TaskPriority priority = Utilities.GetValidEnum<TaskPriority>($"Priority (current: {task.Priority}, options: high, medium, low): ", task.Priority);
            DateTime deadline = Utilities.GetValidDateTime($"Deadline (current: {task.Deadline:yyyy-MM-dd}): ", task.Deadline);

            task.Update(title, description, priority, deadline);
            Utilities.SaveToFile<List<Task>>(path, tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task updated successfully");
            Console.ResetColor();

            task.ToConsole();
        }

        public static void DeleteTask() {
            Task task = FindTaskByTitle();

            tasks.Remove(task);
            Utilities.SaveToFile<List<Task>>(path, tasks);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task deleted successfully");
            Console.ResetColor();
        }

    }
}

