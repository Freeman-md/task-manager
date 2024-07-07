using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskRepository
{
	public class Utilities
	{
        private static string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TaskManager");

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

        public static void SaveToFile<T>(string fileName, T content)
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var path = Path.Combine(directory, fileName);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, // Makes the JSON output pretty-printed
                    Converters = { new JsonStringEnumConverter() } // Handle enum serialization
                };

                string jsonString = JsonSerializer.Serialize(content, options);

                File.WriteAllText(path, jsonString);
            }
            catch
            {
                throw;
            }
        }

        public static T LoadFromFile<T>(string fileName) where T : new()
        {
            try
            {
                var path = Path.Combine(directory, fileName);

                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found. Returning default content.");
                    return new T();
                }

                string jsonString = File.ReadAllText(path);
                var options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };
                return JsonSerializer.Deserialize<T>(jsonString, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading content from file: {ex.Message}");
                return new T(); // Return a new instance in case of error
            }
        }

    }
}

