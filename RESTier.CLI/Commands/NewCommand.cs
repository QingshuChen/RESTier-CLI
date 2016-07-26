using System;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
{
    public class NewCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Creates a new RESTier project.";
            command.HelpOption("-h|--help");

            command.Option("-n|--name", "The name for the new RESTier project", CommandOptionType.SingleValue);
            command.Option("-ns|--namespace", "The namespace for the new RESTier project", CommandOptionType.SingleValue);
            command.Option("-c|--connectionstring",
                "A connection string to a SQL Server database. Used to reverse engineer a RESTier API.",
                CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var name = command.GetOptionValue("name");
                var @namespace = command.GetOptionValue("namespace");
                var parentConnectionString = command.Parent.GetOptionValue("connectionstring");
                var connectionString = command.GetOptionValue("connectionstring");

                ConsoleHelper.WriteLine(ConsoleColor.Green, "Creating new RESTier API.");
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("No name supplied; defaulting to Foo.");
                    name = "Foo";
                }
                if (string.IsNullOrEmpty(@namespace))
                {
                    Console.WriteLine("No namespace supplied; defaulting to RESTier");
                    @namespace = "RESTier";
                }
                if (string.IsNullOrEmpty(connectionString) && string.IsNullOrEmpty(parentConnectionString))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "No connectionstring supplied;\n" +
                        "A connection string is required to createing new RESTier API.\n" +
                        "The right command is like:");
                    ConsoleHelper.WriteLine(ConsoleColor.Green,
                        "RESTier.exe new -c connectionstring [-n projectname] [-ns namespace]");
                    ConsoleHelper.WriteLine("Use \"RESTier new -h\" for more information");
                    return 0;
                }

                if (!string.IsNullOrEmpty(connectionString) && 
                    !string.IsNullOrEmpty(parentConnectionString) &&
                    !connectionString.Equals(parentConnectionString))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, 
                        "Two connectionstrings are supplied and they are not the same;\n" +
                        "The right command is like:");
                    ConsoleHelper.WriteLine(ConsoleColor.Green,
                        "RESTier.exe new -c connectionstring [-n projectname] [-ns namespace]");
                    ConsoleHelper.WriteLine("Use \"RESTier new -h\" for more information");
                    return 0;
                }

                if (string.IsNullOrEmpty(connectionString))
                    connectionString = parentConnectionString;

                var builder = new RESTierProjectBuilder(connectionString, name, @namespace);
                builder.Generate();

                return 0;
            });
        }
    }
}