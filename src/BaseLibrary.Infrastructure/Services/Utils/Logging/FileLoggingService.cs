using BaseLibrary.Application.Interfaces;
using BaseLibrary.Application.Services;
using Microsoft.Extensions.Logging;

namespace BaseLibrary.Infrastructure.Services.Utils.Logging
{
    public class FileLoggingService : BaseLoggingService
    {
        private readonly string _logFilePath;
        private readonly object _lock = new object();

        public FileLoggingService(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        private void WriteToFile(string level, string message)
        {
            lock (_lock)
            {
                File.AppendAllText(_logFilePath,  GetFormattedMessage(level, message));
            }
        }

        public override void LogCritical(string message)
        {
            if (logLevel > LogLevel.Critical) return;
            WriteToFile("CRITICAL", message);
        }

        public override void LogCritical(string message, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            LogCritical(message);
        }

        public override void LogDebug(string message)
        {
            if (logLevel > LogLevel.Debug) return;
            WriteToFile("DEBUG", message);
        }

        public override void LogDebug(string message, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            LogDebug(message);
        }

        public override void LogError(string message)
        {
            if (logLevel > LogLevel.Error) return; ;
            WriteToFile("ERROR", message);
        }

        public override void LogError(string message, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            LogError(message);
        }

        public override void LogInformation(string message)
        {
            if (logLevel > LogLevel.Information) return;
            WriteToFile("INFO", message);
        }

        public override void LogInformation(string message, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            LogInformation(message);
        }

        public override void LogWarning(string message)
        {
            if (logLevel > LogLevel.Warning) return;
            WriteToFile("WARN", message);
        }

        public override void LogWarning(string message, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                message = string.Format(message, args);
            }
            LogWarning(message);
        }
    }
}
