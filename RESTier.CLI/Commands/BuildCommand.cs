using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.RESTier.Cli.ProjectBuilder;
using Microsoft.RESTier.Cli.DependencyResolver;

namespace Microsoft.RESTier.Cli.Commands
{
    public class BuildCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Builds the RESTier project.";
            command.HelpOption("-h|--help");

            var projectName = command.Option("-p|--project", "The name for the RESTier project",
                CommandOptionType.SingleValue);
            var download = command.Option("-d|--download", "Download and install the msbuild automatically if it is not installed",
                CommandOptionType.NoValue);
            var buildSetting = command.Option("-s|--build-setting",
                "Build setting for MSBuild",
                CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                
                string msbuildPath;
                IProjectBuilder msbuild = new MsBuildBuilder(new MsBuildResolver());

                if (download.HasValue())
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Download and install MsBuild.");
                    msbuildPath = msbuild.GetDependencyResolver().Detect();
                    if (string.IsNullOrEmpty(msbuildPath))
                    {
                        msbuild.GetDependencyResolver().Install();
                        return -1;
                    } else
                    {
                        Console.WriteLine("Msbuild has already been installed in {0}", msbuildPath);
                        return -1;
                    }
                }

                ConsoleHelper.WriteLine(ConsoleColor.Green, "Building the RESTier API project.");
                var pName = "";
                if (string.IsNullOrEmpty(projectName.Value()))
                {
                    // Get project in current directory
                    var dir = Directory.GetCurrentDirectory();
                    var sDir = new DirectoryInfo(dir);
                    var fileArray = sDir.GetFiles();
                    foreach (var file in fileArray)
                    {
                        if (file.Extension.Equals(".sln"))
                        {
                            pName = file.Name;
                            break;
                        }
                    }
                }
                else
                {
                    pName = projectName.Value();
                    if (!File.Exists(pName))
                    {
                        ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find the file {0}", pName);
                        ConsoleHelper.WriteLine("Use \"RESTier build -h\" for more information");
                        return 0;
                    }
                }
                if (pName.Length == 0)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red,
                        "Can't find a RESTier project to build in current directory");
                    ConsoleHelper.WriteLine("Use \"RESTier build -h\" for more information");
                    return 0;
                }

                msbuildPath = msbuild.GetDependencyResolver().Detect();
                if (string.IsNullOrEmpty(msbuildPath))
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find a msbuild in {0}", msbuild.GetDependencyResolver().GetPath());
                    ConsoleHelper.WriteLine("Use \"RESTier build -d\" to download and install msbuild automatically");
                    ConsoleHelper.WriteLine("Or you can download and install msbuild through the URL: {0}", msbuild.GetDependencyResolver().GetDownloadInstructionsUri());
                    return -1;
                }

                msbuild.Build(pName, buildSetting.Value());

                return 0;
            });
        }
    }
}