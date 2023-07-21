namespace MediatorWithMaui
{
    public static class Logger
    {
        private static string filePath = Path.Combine(FileSystem.AppDataDirectory, "logs.txt");

        public static async Task WriteLogAsync(string message)
        {
            await File.AppendAllTextAsync(filePath, $"{DateTime.Now.ToString("dd-MM-yyyy")}: {message}\n");
        }

        public static async Task<string> GetLogsAsync()
        {
            return await File.ReadAllTextAsync(filePath);
        }
    }
}
