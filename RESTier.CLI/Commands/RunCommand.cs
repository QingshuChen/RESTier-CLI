using System;
using System.Configuration;
using Microsoft.Extensions.CommandLineUtils;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Microsoft.RESTier.Cli.Commands
{
    public class RunCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Hosts the RESTier API.";

            command.HelpOption("-h|--help");

            var project = command.Option("-p|--project",
                "The name for the RESTier project, default to the project in current directory",
                CommandOptionType.SingleValue);
            var download = command.Option("-d|--download", "Download and install the IIS Express automatically if it is not installed",
                CommandOptionType.NoValue);

            command.OnExecute(() =>
            {
                if (download.HasValue())
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Download and install IIS Express.");
                    if (!IISExpressAutoDetect())
                    {
                        DownloadAndInstallIISExpress();
                        return -1;
                    }
                    else
                    {
                        Console.WriteLine("IIS Express has already been installed in {0}", ConfigurationManager.AppSettings["IISExpressPath"]);
                        return -1;
                    }
                }

                ConsoleHelper.WriteLine(ConsoleColor.Green, "Hosts the RESTier API for {0}", project.Value());
                string projectDirectory = "";
                if (string.IsNullOrEmpty(project.Value()))
                {
                    projectDirectory = Directory.GetCurrentDirectory();
                }
                else
                {
                    if (!File.Exists(project.Value()))
                    {
                        ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find solution: {0}", project.Value());
                        ConsoleHelper.WriteLine("Use \"RESTier run -h\" for more information");
                        return 0;
                    }
                    projectDirectory = Path.GetDirectoryName(project.Value());
                }

                // Set current directory to the directory that contains the RESTier Project
                if (!string.IsNullOrEmpty(projectDirectory))
                    Directory.SetCurrentDirectory(projectDirectory);

                if (!File.Exists(".vs\\config\\applicationhost.config"))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find the configration file '" + projectDirectory + 
                        "\\" + ".vs\\config\\applicationhost.config'");
                    ConsoleHelper.WriteLine("Make sure you have set the correct project");
                    ConsoleHelper.WriteLine("Use \"RESTier run -h\" for more information");
                    return 0;
                }

                if (!IISExpressAutoDetect())
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find a iisexpress.exe in {0}", ConfigurationManager.AppSettings["IISExpressPath"]);
                    ConsoleHelper.WriteLine("Use \"RESTier run -d\" to download and install IIS Express automatically");
                    ConsoleHelper.WriteLine("Or you can download and install IIS Express through the URL: {0}", ConfigurationManager.AppSettings["IISExpressDownloadInstructionsUri"]);
                    return -1;
                }

                CmdIISExpress();

                return 0;
            });
        }

        // Execute the msbuild to build a project
        // Current directory is set to the directory that contains the RESTier Project before executing this function
        private static void CmdIISExpress()
        {   
            Process p = new Process();
            p.StartInfo.FileName =  Path.Combine(ConfigurationManager.AppSettings["IISExpressPath"], "iisexpress.exe");
            p.StartInfo.Arguments = @"/config:.vs\config\applicationhost.config";
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
        }

        private static bool IISExpressAutoDetect()
        {
            return File.Exists(Path.Combine(ConfigurationManager.AppSettings["IISExpressPath"], "iisexpress.exe"));
        }

        private static void DownloadAndInstallIISExpress()
        {
            var webClient = new WebClient();
            String toolName = "iisexpress";
            int index = 0;
            while (File.Exists(toolName + index + ".msi"))
                index++;
            bool type;
            type = Environment.Is64BitOperatingSystem;
            if (type)
            {
                webClient.DownloadFile(ConfigurationManager.AppSettings["IISExpressDownloadInstaller64Uri"], toolName + index + ".msi");
            }
            else
            {
                webClient.DownloadFile(ConfigurationManager.AppSettings["IISExpressDownloadInstaller32Uri"], toolName + index + ".msi");
            }
            Process.Start(toolName + index + ".msi");
        }
    }
}