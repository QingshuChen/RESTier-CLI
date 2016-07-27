using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.RESTier.Cli.Commands;

namespace Microsoft.RESTier.Cli
{
    public class CommandExecutor
    {
        private static readonly Assembly ThisAssembly = typeof (CommandExecutor).GetTypeInfo().Assembly;

        public static CommandLineApplication Create(ref string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "RESTier",
                FullName = "RESTier CLI Commands"
            };

            app.VersionOption("-v|--version", "1.0.0");
            app.HelpOption("-h|--help");

            app.Option("-c|--connectionstring",
                "A connection string to a SQL Server database. Used to reverse engineer a RESTier API.",
                CommandOptionType.SingleValue);
            var downloadOption = app.Option("-d|--download",
                "Automatically downloads dependencies and places in child folder.",
                CommandOptionType.NoValue);

            var checkDependenciesCommand = app.Command("dependencies", c => CheckDependenciesCommand.Configure(c));
            var newCommand = app.Command("new", c => NewCommand.Configure(c));
            app.Command("generate", c => GenerateCommand.Configure(c));
            app.Command("build", c => BuildCommand.Configure(c));
            app.Command("run", c => RunCommand.Configure(c));

            app.OnExecute(
                () =>
                {
                    var connectionString = app.GetOptionValue("connectionstring");
                    if (string.IsNullOrWhiteSpace(connectionString))
                    {
                        WriteLogo();
                        app.ShowHelp();
                        return 0;
                    }
                    var connectionStringBuilder = new SqlConnectionStringBuilder();
                    try
                    {
                        connectionStringBuilder.ConnectionString = connectionString;
                    }
                    catch (ArgumentException e)
                    {
                        throw new ArgumentException("Invalid connection string: " + e.Message, e);
                    }
                    
                    ConsoleHelper.WriteLine(string.Format("Creating new RESTier API for {0}.",
                        connectionStringBuilder.InitialCatalog + connectionStringBuilder.AttachDBFilename));
                    checkDependenciesCommand.Execute();
                    newCommand.Execute();
                    return 0;
                });

            return app;
        }

        private static void WriteLogo()
        {
            ConsoleHelper.WriteLine(@"");
            ConsoleHelper.WriteLine(
                @" __   ___  __  ___    ___  __      ___       ___     __   ___  __  ___                     ___  __  ");
            ConsoleHelper.WriteLine(
                @"|__) |__  /__`  |  | |__  |__) .    |  |__| |__     |__) |__  /__`  |     |  |  /\  \ /     |  /  \ ");
            ConsoleHelper.WriteLine(
                @"|  \ |___ .__/  |  | |___ |  \ .    |  |  | |___    |__) |___ .__/  |     |/\| /~~\  |      |  \__/ ");
            ConsoleHelper.WriteLine(@"");
            ConsoleHelper.WriteLine(
                @"          .----------------.  .----------------.  .----------------.  .----------------.");
            ConsoleHelper.WriteLine(
                @"          | .--------------. || .--------------. || .--------------. || .--------------. |");
            ConsoleHelper.WriteLine(
                @"          | |  _______     | || |  _________   | || |    _______   | || |  _________   | |");
            ConsoleHelper.WriteLine(
                @"          | | |_   __ \    | || | |_   ___  |  | || |   /  ___  |  | || | |  _   _  |  | |");
            ConsoleHelper.WriteLine(
                @"          | |   | |__) |   | || |   | |_  \_|  | || |  |  (__ \_|  | || | |_/ | | \_|  | |");
            ConsoleHelper.WriteLine(
                @"          | |   |  __ /    | || |   |  _|  _   | || |   '.___`-.   | || |     | |      | |");
            ConsoleHelper.WriteLine(
                @"          | |  _| |  \ \_  | || |  _| |___/ |  | || |  |`\____) |  | || |    _| |_     | |");
            ConsoleHelper.WriteLine(
                @"          | | |____| |___| | || | |_________|  | || |  |_______.'  | || |   |_____|    | |");
            ConsoleHelper.WriteLine(
                @"          | |              | || |              | || |              | || |              | |");
            ConsoleHelper.WriteLine(
                @"          | '--------------' || '--------------' || '--------------' || '--------------' |");
            ConsoleHelper.WriteLine(
                @"           '----------------'  '----------------'  '----------------'  '----------------'");
            ConsoleHelper.WriteLine(@"");
        }

        private static string GetVersion()
            => ThisAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
               ?? ThisAssembly.GetName().Version.ToString();

        public static string GetToolName()
            => typeof (CommandExecutor).GetTypeInfo().Assembly.GetName().Name;
    }
}