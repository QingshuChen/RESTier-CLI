using System;

namespace Microsoft.RESTier.Cli
{
    public class ConsoleCommandLogger : CommandLogger
    {
        private static object _lock = new object();
        public static bool IsVerbose { get; set; }

        public static void Output(string message)
        {
            lock (_lock)
            {
                Console.WriteLine(message);
            }
        }

        public static void Error(string message)
        {
            lock (_lock)
            {
                Console.Error.WriteLine(message);
            }
        }

        public static void Verbose(string message)
        {
            if (IsVerbose)
            {
                Output(message);
            }
        }

        public ConsoleCommandLogger(string name)
            : base(name)
        {
        }

        protected override void WriteTrace(string message)
            => Verbose(message.Bold().Black());

        protected override void WriteDebug(string message)
            => Verbose(message.Bold().Black());

        protected override void WriteInformation(string message)
            => Output(message);

        protected override void WriteWarning(string message)
            => Output(message.Bold().Yellow());

        protected override void WriteError(string message)
            => Error(message.Bold().Red());
    }
}