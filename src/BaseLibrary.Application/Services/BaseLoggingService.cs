using BaseLibrary.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Application.Services
{
    public abstract class BaseLoggingService : ILoggingService
    {
        protected readonly string dateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
        protected readonly TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
        protected LogLevel logLevel { get; set; } = LogLevel.Information;

        protected string GetFormattedMessage(string level, string message)
        {
            return $"[{level}][{TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo):dateTimeFormat}][{Environment.CurrentManagedThreadId}] - {message}";
        }

        public abstract void LogCritical(string message);
        public abstract void LogCritical(string message, params object[] args);
        public abstract void LogDebug(string message);
        public abstract void LogDebug(string message, params object[] args);
        public abstract void LogError(string message);
        public abstract void LogError(string message, params object[] args);
        public abstract void LogInformation(string message);
        public abstract void LogInformation(string message, params object[] args);
        public abstract void LogWarning(string message);
        public abstract void LogWarning(string message, params object[] args);
    }
}
