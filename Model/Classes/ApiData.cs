using System.IO;
using System.Reflection;

namespace PhotoAdder.Model.Classes
{
    public static class ApiData
    {
        // Static properties to store data
        public static string ApiKey { get; set; }
        public static string SearchEngineId { get; set; }

        // Static property to get the file path dynamically
        public static string FilePath => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "ApiData.txt");

        // Method to load data from the file into the static properties
        public static void LoadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException($"The file {FilePath} does not exist.");
            }

            string json = File.ReadAllText(FilePath);

            // Deserialize into a helper container class
            var data = System.Text.Json.JsonSerializer.Deserialize<ApiDataContainer>(json);

            // Update static properties with the loaded values
            ApiKey = data.ApiKey;
            SearchEngineId = data.SearchEngineId;
        }

        // Private helper class for deserialization
        private class ApiDataContainer
        {
            public string ApiKey { get; set; }
            public string SearchEngineId { get; set; }
        }
    }
}
