using System;

namespace TaskRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectedInput;

            // TODO: Load Tasks

            DisplayWelcomeMessage();

            do
            {
                DisplayMenu();

                selectedInput = Console.ReadLine();

                switch (selectedInput)
                {
                    case "1":
                        Console.WriteLine("Creating a new task...");
                        TaskRepository.CreateTask();
                        break;
                    case "2":
                        Console.WriteLine("Viewing all tasks...");
                        TaskRepository.ViewTasks();
                        break;
                    case "3":
                        Console.WriteLine("Editing a task...");
                        TaskRepository.EditTask();
                        break;
                    case "4":
                        Console.WriteLine("Deleting a task...");
                        TaskRepository.DeleteTask();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }
            } while (selectedInput != "5");

            DisplayGoodbyeMessage();
        }

        static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*********************************************");
            Console.WriteLine("*                                           *");
            Console.WriteLine("*       Welcome to the Task Manager CLI      *");
            Console.WriteLine("*                                           *");
            Console.WriteLine("*********************************************");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThis application helps you manage your tasks efficiently.");
            Console.ResetColor();
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPlease choose an option from the menu below:");
            Console.WriteLine("1. Create a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Edit a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.ResetColor();
        }

        static void DisplayGoodbyeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n*********************************************");
            Console.WriteLine("*                                           *");
            Console.WriteLine("*      Thank you for using Task Manager     *");
            Console.WriteLine("*             Have a great day!             *");
            Console.WriteLine("*                                           *");
            Console.WriteLine("*********************************************");
            Console.ResetColor();
        }
    }
}
