using System;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
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
                var name = command.GetOptionValue("name");
                var @namespace = command.GetOptionValue("namespace");
                var connectionString = command.Parent.GetOptionValue("connectionstring");

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
                if (string.IsNullOrEmpty(connectionString))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "No connectionstring supplied;\n" + 
                        "A connection string is required to createing new RESTier API.\n" +
                        "The format of connection string is like:\n" +
                        "\"Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;\"");
                    command.Parent.ShowHelp();
                    return 0;
                }

                var builder = new RESTierProjectBuilder(connectionString, name, @namespace);
                builder.Generate();

                return 0;
            });
        }
    }
}