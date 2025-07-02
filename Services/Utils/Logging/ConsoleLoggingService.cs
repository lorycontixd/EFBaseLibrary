namespace BaseLibrary.Services.Utils.Logging
{
    public class ConsoleLoggingService : ILoggingService
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"[INFO] {message}");
        }
        public void LogInformation(string message, params object[] args)
        {
            Console.WriteLine($"[INFO] {string.Format(message, args)}");
        }
        public void LogWarning(string message)
        {
            Console.WriteLine($"[WARN] {message}");
        }
        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine($"[WARN] {string.Format(message, args)}");
        }
        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {message}");
        }
        public void LogError(string message, params object[] args)
        {
            Console.WriteLine($"[ERROR] {string.Format(message, args)}");
        }
        public void LogCritical(string message)
        {
            Console.WriteLine($"[CRITICAL] {message}");
        }
        public void LogCritical(string message, params object[] args)
        {
            Console.WriteLine($"[CRITICAL] {string.Format(message, args)}");
        }
        public void LogDebug(string message)
        {
            Console.WriteLine($"[DEBUG] {message}");
        }
        public void LogDebug(string message, params object[] args)
        {
            Console.WriteLine($"[DEBUG] {string.Format(message, args)}");
        }
    }
}
