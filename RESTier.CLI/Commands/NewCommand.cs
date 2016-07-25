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
                }
                return 0;
            });
        }
    }
}