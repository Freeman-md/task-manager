using System;
namespace TaskManager
{
	public class Utilities
	{
		public Utilities()
		{
		}

		public static string GetValidInput(string prompt)
		{
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public static T GetValidEnum<T>(string prompt) where T : struct, Enum
        {
            T result;
            Console.Write(prompt);
            while (!Enum.TryParse(Console.ReadLine().ToUpper(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Invalid input. {prompt}");
                Console.ResetColor();
            }
            return result;
        }

        public static DateTime GetValidDateTime(string prompt)
        {
            DateTime result;
            Console.Write(prompt);
            while (!DateTime.TryParse(Console.ReadLine(), out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Invalid date format. {prompt}");
                Console.ResetColor();
            }
            return result;
        }
    }
}

