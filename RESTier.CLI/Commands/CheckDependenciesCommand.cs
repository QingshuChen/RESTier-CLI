using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli.Commands
{
    public class CheckDependenciesCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Determines whether dependencies are accessible to RESTier.exe";

            command.OnExecute(() =>
            {
                ConsoleHelper.WriteVerbose("Checking dependencies.");
                var downloadDependencies = command.Parent.Options.Exists(o => o.LongName == "download");
                var dependencies = new[]
                {
                    new Dependency
                    {
                        Name = "msbuild",
                        Path = ConfigurationManager.AppSettings["msbuild"],
                        DownloadInstructionsUri = "https://www.microsoft.com/en-us/download/details.aspx?id=40760",
                        DownloadInstallerUri =
                            "https://download.microsoft.com/download/9/B/B/9BB1309E-1A8F-4A47-A6C5-ECF76672A3B3/BuildTools_Full.exe",
                        FileName = "msbuild.exe",
                        InstallerExe = "BuildTools_Full.exe",
                        InstallerArgs = "/Q /Layout {dependencypath}"
                    }
                };
                foreach (var dependency in dependencies)
                {
                    if (!DependencyExists(dependency))
                    {
                        if (downloadDependencies)
                        {
                            DownloadDependency(dependency);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                return 0;
            });
        }
        
        private static void DownloadDependency(Dependency dependency)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "dependencies", dependency.Name);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            ConsoleHelper.WriteVerbose("Downloading {0}.", dependency.Name);
            try
            {
                var dependencyPath = Path.Combine(directoryPath, dependency.InstallerExe);
                var webClient = new WebClient();
                webClient.DownloadFile(dependency.DownloadInstallerUri, dependencyPath);
                dependency.InstallerArgs = dependency.InstallerArgs.Replace("{dependencypath}",
                    directoryPath);
                Process.Start(dependencyPath, dependency.InstallerArgs);
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteError(ex.Message + ex.InnerException.Message);
            }
        }

        private static bool DependencyExists(Dependency dependency)
        {
            ConsoleHelper.WriteVerbose("Checking for {0}.", dependency.Name);

            ConsoleHelper.WriteVerbose("Checking for {0} at {1}.", dependency.Name, dependency.Path);
            if (File.Exists(dependency.Path))
            {
                ConsoleHelper.WriteVerbose("Found {0} at {1}.", dependency.Name, dependency.Path);
                return true;
            }
            
            // TODO #5: Place static strings into a centralized place.
            var alternatePath = Path.Combine("dependencies", dependency.Name, Path.GetFileName(dependency.Path));
            if (File.Exists(alternatePath))
            {
                ConsoleHelper.WriteVerbose("Found {0} at {1}.", dependency.Name, alternatePath);
                return true;
            }

            ConsoleHelper.WriteError(
                "Could not locate {0}. You can manually download and install this dependency by following the instructions here: {1}",
                dependency.Name, dependency.DownloadInstructionsUri);
            return false;
        }
    }
}