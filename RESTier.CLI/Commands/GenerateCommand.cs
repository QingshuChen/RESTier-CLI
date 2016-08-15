using System;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
{
    public class GenerateCommand
    {
        // Doesn't support generate command currently
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Reverse engineers a data access layer from a database.";

            command.Option("-c|--connection-string", "The connection string to connect to the database.",
                CommandOptionType.SingleValue);
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