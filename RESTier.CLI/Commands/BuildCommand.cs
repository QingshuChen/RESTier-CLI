using System;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
{
    public class BuildCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Builds the RESTier project.";
            command.HelpOption("--help");

            command.Option("-p|--project", "The name for the RESTier project", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                Console.WriteLine("Built {0} successfully.", command.GetOptionValue("p"));
                return 0;
            });
        }
    }
}