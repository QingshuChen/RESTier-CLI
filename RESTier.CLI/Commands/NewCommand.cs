using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.RESTier.Cli.ProjectBuilder;
using Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio;
using Microsoft.RESTier.Cli.Database;
using MySql.Data.MySqlClient;

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
                var dbOption = command.Parent.GetOptionValue("database");

                if (!string.IsNullOrEmpty(name))
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Creating new RESTier API {0}.", name);
                else
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Creating new RESTier API.");

                if (string.IsNullOrEmpty(connectionString))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "A connection string is required to create new RESTier API.");
                    Console.WriteLine("Use \"RESTier -c connectionstring new\" to create new RESTier API.");
                    Console.WriteLine("Use \"RESTier new -h\" for more infomation");
                    return 0;
                }

                if (string.IsNullOrEmpty(dbOption))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "A database type is required to create new RESTier API.");
                    Console.WriteLine("Use \"RESTier -c connectionstring -db dbtype new\" to create new RESTier API.");
                    Console.WriteLine("Use \"RESTier new -h\" for more infomation");
                    return 0;
                }

                var dbSetting = DatabaseSettingsFactory.Create(dbOption);
                if (dbSetting == null)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "A database type {0} is not supported.", dbOption);
                    Console.WriteLine("We only support SQLServer and MySql currently.");
                    Console.WriteLine("Use \"RESTier new -h\" for more infomation.");
                    return 0;
                }

                if (string.IsNullOrEmpty(name))
                {
                    if (dbSetting.DBType == DatabaseType.SQLServer)
                    {
                        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                        name = connectionStringBuilder.InitialCatalog;
                        if (string.IsNullOrEmpty(name))
                        {
                            name = Path.GetFileNameWithoutExtension(connectionStringBuilder.AttachDBFilename);
                        }
                        
                    }
                    else if (dbSetting.DBType == DatabaseType.MYSQL)
                    {
                        var c = new MySqlConnectionStringBuilder(connectionString);
                        name = c.Database;
                    }
                    foreach (var option in command.Options)
                    {
                        if (option.LongName.Equals("name"))
                        {
                            option.Values.Add(name);
                            break;
                        }
                    }
                    ConsoleHelper.WriteLine("No name supplied; defaulting to \"{0}\".", name);
                }

                if (string.IsNullOrEmpty(@namespace))
                {
                    ConsoleHelper.WriteLine("No namespace supplied; defaulting to \"RESTier\".");
                    @namespace = "RESTier";
                }
                IProjectBuilder aspDotNetProject = new AspDotNetProjectBuilder(name, @namespace, Directory.GetCurrentDirectory());
                IProjectBuilder dataProject = new DatabaseModelProjectBuilder(aspDotNetProject, dbSetting, connectionString);
                IProjectBuilder restierProject = new RESTierProjectBuilder(dataProject);
                restierProject.Create();
                return 0;
            });
        }
    }
}