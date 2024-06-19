using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectedInput;

            Console.WriteLine("Welcome to the Task Manager CLI!");
            Console.WriteLine("This application helps you manage your tasks efficiently.");

            do
            {
                DisplayMenu();

                selectedInput = Console.ReadLine();

                switch (selectedInput)
                {
                    case "1":
                        // create task
                        Console.WriteLine("Creating a new task...");
                        break;
                    case "2":
                        // view tasks
                        Console.WriteLine("Viewing all tasks...");
                        break;
                    case "3":
                        // edit task
                        Console.WriteLine("Editing a task...");
                        break;
                    case "4":
                        // delete task
                        Console.WriteLine("Deleting a task...");
                        break;
                    case "5":
                        Console.Write("Are you sure you want to exit? (y/n) ");
                        string decision = Console.ReadLine().ToLower();
                        if (decision == "y")
                        {
                            selectedInput = "5";
                        }
                        else
                        {
                            selectedInput = "0"; // Reset to keep the loop going
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (selectedInput != "5");

            Console.WriteLine("Thank you for using the Task Manager CLI. Goodbye!");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nPlease choose an option from the menu below:");
            Console.WriteLine("1. Create a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Edit a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
        }
    }
}
