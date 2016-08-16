using System;
using System.Configuration;
using Microsoft.Extensions.CommandLineUtils;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.RESTier.Cli.Uitls.WebServerUtils;
using Microsoft.RESTier.Cli.Uitls.DetectionUtils;

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
                DetectionUtil detectionUtil = new DetectionUtilForFile();
                detectionUtil.SoftwareName = "IISExpress";
                detectionUtil.ExecutableFileName = "iisexpress.exe";
                detectionUtil.Path = ConfigurationManager.AppSettings["IISExpressPath"];
                detectionUtil.DownloadInstructionsUri = ConfigurationManager.AppSettings["IISExpressDownloadInstructionsUri"];
                bool type;
                type = Environment.Is64BitOperatingSystem;
                if (type) 
                    detectionUtil.DownloadInstallerUri = ConfigurationManager.AppSettings["IISExpressDownloadInstaller64Uri"];
                else
                    detectionUtil.DownloadInstallerUri = ConfigurationManager.AppSettings["IISExpressDownloadInstaller32Uri"];
                WebServerUtil webServer = new IISExpressUtil(detectionUtil);
                string path = webServer.GetDetectionUtil().Detect();
                if (download.HasValue())
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Download and install {0}.", webServer.GetDetectionUtil().SoftwareName);
                    if (string.IsNullOrEmpty(path))
                    {
                        webServer.GetDetectionUtil().Install();
                        return -1;
                    }
                    else
                    {
                        Console.WriteLine("{0} has already been installed in {1}", webServer.GetDetectionUtil().SoftwareName, webServer.GetDetectionUtil().Path);
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

                if (string.IsNullOrEmpty(path))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find a {0} in {1}", webServer.GetDetectionUtil().SoftwareName, webServer.GetDetectionUtil().Path);
                    ConsoleHelper.WriteLine("Use \"RESTier run -d\" to download and install {0} automatically", webServer.GetDetectionUtil().SoftwareName);
                    ConsoleHelper.WriteLine("Or you can download and install {0} through the URL: {1}",
                        webServer.GetDetectionUtil().SoftwareName, webServer.GetDetectionUtil().DownloadInstructionsUri);
                    return -1;
                }

                if (!string.IsNullOrEmpty(projectDirectory))
                    webServer.Run(projectDirectory);
                else
                    webServer.Run(Directory.GetCurrentDirectory());

                return 0;
            });
        }
    }
}