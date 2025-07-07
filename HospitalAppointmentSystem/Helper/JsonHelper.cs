using System.Text.Json;

namespace HospitalAppointmentSystem.Helper
{
    public static class JsonHelper
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public static void Save<T>(T data, string fileName)
        {
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(fileName, json);
        }

        public static T Load<T>(string fileName)
        {
            if (!File.Exists(fileName))
                return Activator.CreateInstance<T>();

            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<T>(json) ?? Activator.CreateInstance<T>();
        }
    }
}
