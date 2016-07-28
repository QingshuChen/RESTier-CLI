using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.RESTier.Cli.Commands;
using System.IO;

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
            app.Option("-a|--all", "Execute the new, build, run commands together", CommandOptionType.NoValue);

            app.Command("new", c => NewCommand.Configure(c));
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
                    app.Commands.First(c => c.Name == "new").Execute();

                    // execute the build and run command for the -a option
                    if (app.Options.First(c => (c.LongName == "all" || c.ShortName == "a")).HasValue())
                    {
                        string projectName = app.Commands.First(c => c.Name == "new").GetOptionValue("name");
                        if (string.IsNullOrEmpty(projectName))
                        {
                            projectName = Path.GetFileNameWithoutExtension(connectionStringBuilder.AttachDBFilename);
                        }
                        string[] argsForBuild = { "-p", projectName + "\\" + projectName + ".sln" };
                        app.Commands.First(c => c.Name == "build").Execute(argsForBuild);

                        app.Commands.First(c => c.Name == "run").Execute(argsForBuild);
                    }
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