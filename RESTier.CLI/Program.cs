using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Microsoft.RESTier.Cli
{
    public class Program
    {
        public static int Main(string[] args)
        {
            ConsoleCommandLogger.IsVerbose = HandleVerboseOption(ref args);
            HandleDebugSwitch(ref args);

            try
            {
                return CommandExecutor.Create(ref args).Execute(args);
            }
            catch (Exception ex)
            {
                // TODO ensure always a json response if --json is supplied
                if (ex is TargetInvocationException)
                {
                    ex = ex.InnerException;
                }

                ConsoleCommandLogger.Error(ex.Message.Bold().Red());
                return 1;
            }
        }

        private static bool HandleVerboseOption(ref string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-v" || args[i] == "--verbose")
                {
                    args = args.Take(i).Concat(args.Skip(i + 1)).ToArray();
                    return true;
                }
            }
            return false;
        }

        [Conditional("DEBUG")]
        private static void HandleDebugSwitch(ref string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "--debug")
                {
                    args = args.Take(i).Concat(args.Skip(i + 1)).ToArray();
                    Console.WriteLine("Waiting for debugger to attach. Press ENTER to continue");
                    Console.WriteLine($"Process ID: {Process.GetCurrentProcess().Id}");
                    Console.ReadLine();
                }
            }
        }
    }
}