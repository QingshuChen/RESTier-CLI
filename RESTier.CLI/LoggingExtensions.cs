using Microsoft.Extensions.Logging;

namespace Microsoft.RESTier.Cli
{
    internal static class LoggingExtensions
    {
        public const string CommandsLoggerName = "Microsoft.RESTier.Cli";

        public static ILogger CreateCommandsLogger(this ILoggerFactory loggerFactory)
            => loggerFactory.CreateLogger(CommandsLoggerName);

        public static ILogger CreateCommandsLogger(this ILoggerProvider loggerProvider)
            => loggerProvider.CreateLogger(CommandsLoggerName);
    }
}