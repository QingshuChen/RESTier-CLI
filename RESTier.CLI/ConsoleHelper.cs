using System;

namespace Microsoft.RESTier.Cli
{
    public class ConsoleHelper
    {
        private static readonly object _lock = new object();
        public static bool IsVerbose { get; set; }

        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            WritePretty(color, Console.WriteLine, format, args);
        }

        public static void Write(string format, params object[] args)
        {
            WritePlain(Console.Write, format, args);
        }

        public static void Write(ConsoleColor color, string format, params object[] args)
        {
            WritePretty(color, Console.Write, format, args);
        }

        public static void WriteLine(string format, params object[] args)
        {
            WritePlain(Console.WriteLine, format, args);
        }

        public static void WriteError(string format, params object[] args)
        {
            WritePretty(ConsoleColor.Red, Console.Error.WriteLine, format, args);
        }

        private static void WritePlain(Action<string> action, string format, params object[] args)
        {
            lock (_lock)
            {
                action(string.Format(format, args));
            }
        }

        private static void WritePretty(ConsoleColor color, Action<string> action, string format, params object[] args)
        {
            lock (_lock)
            {
                var foregroundColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                action(string.Format(format, args));
                Console.ForegroundColor = foregroundColor;
            }
        }

        public static void WriteVerbose(string message, params object[] args)
        {
            if (IsVerbose)
            {
                WriteLine(ConsoleColor.Yellow, message, args);
            }
        }

        public void WriteTrace(string message)
            => WriteVerbose(message);

        public void WriteDebug(string message)
            => WriteVerbose(message);

        public void WriteInformation(string message)
            => WriteLine(message);

        public void WriteWarning(string message)
            => WriteLine(ConsoleColor.Yellow, message);
    }
}