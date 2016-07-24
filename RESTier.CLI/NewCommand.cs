using Microsoft.Extensions.CommandLineUtils;
using System;

namespace Microsoft.RESTier.Cli
{
    public class NewCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Creates a new RESTier project.";

            command.Option("-n|--name", "The name for the new RESTier project", CommandOptionType.SingleValue);
            command.Option("-ns|--namespace", "The namespace for the new RESTier project", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                ConsoleCommandLogger.Output("Creating new RESTier API.");
                if (string.IsNullOrEmpty(command.GetOptionValue("n")))
                {
                    Console.WriteLine("No name supplied; defaulting to Foo.");
                }
                return 0;
            });
        }
    }
}
