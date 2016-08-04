using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
{
    public class NewCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Creates a new RESTier project.";
            command.HelpOption("-h|--help");

            var nameOption = command.Option("-n|--name", "The name for the new RESTier project",
                CommandOptionType.SingleValue);
            var namespaceOption = command.Option("-ns|--namespace", "The namespace for the new RESTier project",
                CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var name = nameOption.Value();
                var @namespace = namespaceOption.Value();
                var connectionString = command.Parent.GetOptionValue("connectionstring");

                if (!string.IsNullOrEmpty(name))
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Creating new RESTier API {0}.", name);
                else
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Creating new RESTier API.");

                if (string.IsNullOrEmpty(connectionString))
                {
                    command.Parent.ShowHelp();
                }
                if (string.IsNullOrEmpty(name))
                {
                    // TODO #4: Need better error handling for connection string.
                    var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                    name = connectionStringBuilder.InitialCatalog;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = Path.GetFileNameWithoutExtension(connectionStringBuilder.AttachDBFilename);
                    }
                    ConsoleHelper.WriteLine("No name supplied; defaulting to \"{0}\".", name);
                }
                if (string.IsNullOrEmpty(@namespace))
                {
                    ConsoleHelper.WriteLine("No namespace supplied; defaulting to \"RESTier\".");
                    @namespace = "RESTier";
                }

                var builder = new RESTierProjectBuilder(connectionString, name, @namespace);
                return builder.Generate();
            });
        }
    }
}