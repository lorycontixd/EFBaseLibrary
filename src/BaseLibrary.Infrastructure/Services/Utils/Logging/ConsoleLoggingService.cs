using BaseLibrary.Application.Interfaces.Utils;
using BaseLibrary.Application.Services.Utils;
using Microsoft.Extensions.Logging;

namespace BaseLibrary.Infrastructure.Services.Utils.Logging
{
    public class ConsoleLoggingService : BaseLoggingService
    {
        private bool _useColours = true;

        public void SetUseColours(bool useColours)
        {
            _useColours = useColours;
        }
        public void SetLogLevel(LogLevel level)
        {
            logLevel = level;
        }

        public override void LogInformation(string message)
        {
            if (logLevel > LogLevel.Information) return;
            Console.WriteLine(GetFormattedMessage("INFO", message));
        }
        public override void LogInformation(string message, params object[] args)
        {
            LogInformation(string.Format(message, args));
        }
        public override void LogWarning(string message)
        {
            if (logLevel > LogLevel.Warning) return;
            Console.WriteLine(GetFormattedMessage("WARN", message));
        }
        public override void LogWarning(string message, params object[] args)
        {
            LogWarning(string.Format(message, args));
        }
        public override void LogError(string message)
        {
            if (logLevel > LogLevel.Error) return;
            Console.WriteLine(GetFormattedMessage("ERROR", message));
        }
        public override void LogError(string message, params object[] args)
        {
            LogError(string.Format(message, args));
        }
        public override void LogCritical(string message)
        {
            if (logLevel > LogLevel.Critical) return;
            Console.WriteLine(GetFormattedMessage("CRITICAL", message));
        }
        public override void LogCritical(string message, params object[] args)
        {
            LogCritical(string.Format(message, args));
        }
        public override void LogDebug(string message)
        {
            if (logLevel > LogLevel.Debug) return;
            Console.WriteLine(GetFormattedMessage("DEBUG", message));
        }
        public override void LogDebug(string message, params object[] args)
        {
            LogDebug(string.Format(message, args));
        }
    }
}
