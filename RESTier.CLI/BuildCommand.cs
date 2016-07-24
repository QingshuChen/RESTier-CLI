using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace Microsoft.RESTier.Cli
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
