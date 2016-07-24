using Microsoft.Extensions.CommandLineUtils;
using System;

namespace Microsoft.RESTier.Cli
{
    public class GenerateCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Reverse engineers a data access layer from a database.";

            command.Option("-c|--connection-string", "The connection string to connect to the database.", CommandOptionType.SingleValue);
            command.Option("-p|--project", "The name for the RESTier project", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                Console.WriteLine("Generated a DAL.");
                return 0;
            });
        }
    }
}
