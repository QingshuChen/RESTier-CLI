using System;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Microsoft.RESTier.Cli
{
    public abstract class CommandLogger : ILogger
    {
        private static readonly string[] _includedNames =
        {
            LoggingExtensions.CommandsLoggerName
        };

        private readonly bool _enabledByName;

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected CommandLogger(string name)
        {
            Check.NotEmpty(name, nameof(name));

            _enabledByName = _includedNames.Contains(name);
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public virtual bool IsEnabled(LogLevel logLevel) => _enabledByName;

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public virtual IDisposable BeginScope(object state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public virtual void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = new StringBuilder();
            if (formatter != null)
            {
                message.Append(formatter(state, exception));
            }
            else if (state != null)
            {
                message.Append(state);

                if (exception != null)
                {
                    message.Append(Environment.NewLine);
                    message.Append(exception);
                }
            }

            switch (logLevel)
            {
                case LogLevel.Error:
                    WriteError(message.ToString());
                    break;
                case LogLevel.Warning:
                    WriteWarning(message.ToString());
                    break;
                case LogLevel.Information:
                    WriteInformation(message.ToString());
                    break;
                case LogLevel.Debug:
                    WriteDebug(message.ToString());
                    break;
                case LogLevel.Trace:
                    WriteTrace(message.ToString());
                    break;
                default:
                    WriteDebug(message.ToString());
                    Debug.Fail("Unexpected event type: " + logLevel);
                    break;
            }
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public virtual IDisposable BeginScope<TState>(TState state) => null;

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected abstract void WriteError(string message);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected abstract void WriteWarning(string message);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected abstract void WriteInformation(string message);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected abstract void WriteDebug(string message);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected abstract void WriteTrace(string message);
    }
}
