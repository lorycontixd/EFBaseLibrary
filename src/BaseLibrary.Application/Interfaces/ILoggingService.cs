namespace BaseLibrary.Application.Interfaces
{
    public interface ILoggingService
    {
        public void LogInformation(string message);
        public void LogInformation(string message, params object[] args);
        public void LogWarning(string message);
        public void LogWarning(string message, params object[] args);
        public void LogError(string message);
        public void LogError(string message, params object[] args);
        public void LogCritical(string message);
        public void LogCritical(string message, params object[] args);
        public void LogDebug(string message);
        public void LogDebug(string message, params object[] args);
    }
}
