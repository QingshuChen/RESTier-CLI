using System;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
{
    public class GenerateCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Reverse engineers a data access layer from a database.";

            command.Option("-p|--project", "The name for the RESTier project", CommandOptionType.SingleValue);
            command.HelpOption("-h|--help");

            command.OnExecute(() =>
            {
                Console.WriteLine("Generated a DAL.");
                return 0;
            });
        }
    }
}