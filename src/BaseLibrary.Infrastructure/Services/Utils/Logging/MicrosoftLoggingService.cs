using BaseLibrary.Application.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Infrastructure.Services.Utils.Logging
{
    public class MicrosoftLoggingService : BaseLoggingService
    {
        private readonly ILogger<MicrosoftLoggingService> _logger;

        public MicrosoftLoggingService(ILogger<MicrosoftLoggingService> logger)
        {
            _logger = logger;
        }

        public override void LogDebug(string message) =>
            _logger.LogDebug(message);

        public override void LogDebug(string message, params object[] args) =>
            _logger.LogDebug(message, args);
        public override void LogInformation(string message) =>
            _logger.LogInformation(message);

        public override void LogInformation(string message, params object[] args) =>
            _logger.LogInformation(message, args);
        public override void LogWarning(string message) =>
            _logger.LogInformation(message);

        public override void LogWarning(string message, params object[] args) =>
            _logger.LogInformation(message, args);
        public override void LogError(string message) =>
            _logger.LogInformation(message);

        public override void LogError(string message, params object[] args) =>
            _logger.LogInformation(message, args);
        public override void LogCritical(string message) =>
            _logger.LogInformation(message);

        public override void LogCritical(string message, params object[] args) =>
            _logger.LogInformation(message, args);
    }
}
