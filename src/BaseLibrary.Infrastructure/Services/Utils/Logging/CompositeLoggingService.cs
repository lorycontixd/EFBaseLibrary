using BaseLibrary.Application.Interfaces;
using BaseLibrary.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Infrastructure.Services.Utils.Logging
{
    /// <summary>
    /// Logging service that aggregates multiple logging services into a single service.
    /// All log messages are forwarded to all registered logging services.
    /// 
    /// Example registration in EF Core:
    ///     services.AddSingleton<ILoggingService>(provider =>
    ///     {
    ///         var loggers = new List<ILoggingService>
    ///         {
    ///             new ConsoleLoggingService(),
    ///             new FileLoggingService("app.log"),
    ///             new DatabaseLoggingService(provider.GetService<DbContext>())
    ///         };
    ///         return new CompositeLoggingService(loggers);
    ///     });
    /// 
    /// </summary>
    public class CompositeLoggingService : BaseLoggingService
    {
        private readonly IEnumerable<ILoggingService> _loggers;

        public CompositeLoggingService(IEnumerable<ILoggingService> loggers)
        {
            _loggers = loggers ?? throw new ArgumentNullException(nameof(loggers));
        }

        public override void LogDebug(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogDebug(message);
            }
        }
        public override void LogDebug(string message, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.LogDebug(message, args);
            }
        }
        public override void LogInformation(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInformation(message);
            }
        }
        public override void LogInformation(string message, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInformation(message, args);
            }
        }
        public override void LogWarning(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogWarning(message);
            }
        }
        public override void LogWarning(string message, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.LogWarning(message, args);
            }
        }
        public override void LogError(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(message);
            }
        }
        public override void LogError(string message, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(message, args);
            }
        }
        public override void LogCritical(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogCritical(message);
            }
        }
        public override void LogCritical(string message, params object[] args)
        {
            foreach (var logger in _loggers)
            {
                logger.LogCritical(message, args);
            }
        }
    }
}
