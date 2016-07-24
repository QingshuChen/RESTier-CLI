using Microsoft.Extensions.CommandLineUtils;
using System;

namespace Microsoft.RESTier.Cli
{
    public class RunCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Hosts the RESTier API.";

            command.Option("-c|--connection-string", "The connection string to connect to the database.", CommandOptionType.SingleValue);
            command.Option("-p|--project", "The name for the RESTier project", CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                Console.WriteLine("API is hosted at http://localhost:8080.");
                return 0;
            });
        }
    }
}
