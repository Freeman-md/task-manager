using System;
namespace TaskRepository
{
	public class Utilities
	{
		public Utilities()
		{
		}

		public static string GetValidInput(string prompt, string defaultValue = "")
		{
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();

                input = input.Length > 0
                        ? input
                        : defaultValue;
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public static T GetValidEnum<T>(string prompt, T? defaultValue = null) where T : struct, Enum
        {
            T result;
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input) && defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }

                if (Enum.TryParse(input.ToUpper(), out result))
                {
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid value.");
                Console.ResetColor();

            } while (true);
        }

        public static DateTime GetValidDateTime(string prompt, DateTime? defaultValue = null)
        {
            DateTime result;
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input) && defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }

                if (DateTime.TryParse(input, out result))
                {
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Please enter a valid date.");
                Console.ResetColor();

            } while (true);
        }
    }
}

