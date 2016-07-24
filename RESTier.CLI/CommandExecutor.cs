using Microsoft.Extensions.CommandLineUtils;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Microsoft.RESTier.Cli
{
    public class CommandExecutor
    {
        public static CommandLineApplication Create(ref string[] args)
        {
            var app = new CommandLineApplication()
            {
                Name = "RESTier",
                FullName = "RESTier CLI Commands"
            };
            
            app.VersionOption("--version","1.0.0");
            app.HelpOption("--help");

            app.Option("-c|--connectionstring", "A connection string to a SQL Server database. Used to reverse engineer a RESTier API.", CommandOptionType.SingleValue);

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
                    else
                    {
                        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                        ConsoleCommandLogger.Output(string.Format("Creating new RESTier API for {0}.", connectionStringBuilder.InitialCatalog));
                        app.Commands.First(c => c.Name == "new").Execute();
                        return 0;   
                    }
                });

            return app;
        }

        private static void WriteLogo()
        {
            ConsoleCommandLogger.Output(@"");
            ConsoleCommandLogger.Output(@" __   ___  __  ___    ___  __      ___       ___     __   ___  __  ___                     ___  __  ");
            ConsoleCommandLogger.Output(@"|__) |__  /__`  |  | |__  |__) .    |  |__| |__     |__) |__  /__`  |     |  |  /\  \ /     |  /  \ ");
            ConsoleCommandLogger.Output(@"|  \ |___ .__/  |  | |___ |  \ .    |  |  | |___    |__) |___ .__/  |     |/\| /~~\  |      |  \__/ ");
            ConsoleCommandLogger.Output(@"");
            ConsoleCommandLogger.Output(@"          .----------------.  .----------------.  .----------------.  .----------------.");
            ConsoleCommandLogger.Output(@"          | .--------------. || .--------------. || .--------------. || .--------------. |");
            ConsoleCommandLogger.Output(@"          | |  _______     | || |  _________   | || |    _______   | || |  _________   | |");
            ConsoleCommandLogger.Output(@"          | | |_   __ \    | || | |_   ___  |  | || |   /  ___  |  | || | |  _   _  |  | |");
            ConsoleCommandLogger.Output(@"          | |   | |__) |   | || |   | |_  \_|  | || |  |  (__ \_|  | || | |_/ | | \_|  | |");
            ConsoleCommandLogger.Output(@"          | |   |  __ /    | || |   |  _|  _   | || |   '.___`-.   | || |     | |      | |");
            ConsoleCommandLogger.Output(@"          | |  _| |  \ \_  | || |  _| |___/ |  | || |  |`\____) |  | || |    _| |_     | |");
            ConsoleCommandLogger.Output(@"          | | |____| |___| | || | |_________|  | || |  |_______.'  | || |   |_____|    | |");
            ConsoleCommandLogger.Output(@"          | |              | || |              | || |              | || |              | |");
            ConsoleCommandLogger.Output(@"          | '--------------' || '--------------' || '--------------' || '--------------' |");
            ConsoleCommandLogger.Output(@"           '----------------'  '----------------'  '----------------'  '----------------'");
            ConsoleCommandLogger.Output(@"");
        }

        private static readonly Assembly ThisAssembly = typeof(CommandExecutor).GetTypeInfo().Assembly;

        private static string GetVersion()
            => ThisAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
                ?? ThisAssembly.GetName().Version.ToString();

        public static string GetToolName()
            => typeof(CommandExecutor).GetTypeInfo().Assembly.GetName().Name;
    }
}
