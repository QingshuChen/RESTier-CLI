using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.Net;

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

                if (download.HasValue())
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Green, "Download and install MsBuild.");
                    msbuildPath = MsBuildAutoDetect(false);
                    if (msbuildPath == null)
                    {
                        DownloadAndInstallMsBuild();
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

                msbuildPath = MsBuildAutoDetect(true);
                if (msbuildPath == null)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find a msbuild in {0}", ConfigurationManager.AppSettings["MsBuildDirectory"]);
                    ConsoleHelper.WriteLine("Use \"RESTier build -d\" to download and install msbuild automatically");
                    ConsoleHelper.WriteLine("Or you can download and install msbuild through the URL: {0}", ConfigurationManager.AppSettings["MsBuildDownloadInstructionsUri"]);
                    return -1;
                }

                CmdMSBuild(pName, buildSetting.Value(), msbuildPath);

                return 0;
            });
        }

        // execute the msbuild to build a project
        private static void CmdMSBuild(string projectName, string buildSetting, string msbuildPath)
        {
            var p = new Process();

            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.Arguments = "/c " + "\"" + Path.Combine(msbuildPath, @"bin\MSBuild.exe") + "\" " + projectName +
                (string.IsNullOrEmpty(buildSetting) ? "" : " " + buildSetting);

            Console.WriteLine(p.StartInfo.Arguments);

            p.Start();

            p.WaitForExit();
        }

        // Return the path of the latest version of msbuild
        // If no msbuild is found, return null
        private static string MsBuildAutoDetect(bool showMsBuildInfo)
        {
            if (Directory.Exists(ConfigurationManager.AppSettings["MsBuildDirectory"]))
            {
                try
                {
                    double max = 0;
                    double version;
                    int index = -1;
                    if (!Directory.Exists(ConfigurationManager.AppSettings["MsBuildDirectory"]))
                        return null;
                    string[] subDirectories = Directory.GetDirectories(ConfigurationManager.AppSettings["MsBuildDirectory"]);
                    for (int i = 0; i < subDirectories.Length; i++)
                    {
                        try
                        {
                            version = Convert.ToDouble(subDirectories[i].Substring(ConfigurationManager.AppSettings["MsBuildDirectory"].Length));
                            if (version > max)
                            {
                                max = version;
                                index = i;
                            }
                        }
                        catch 
                        {
                            // ignore the exception
                        }
                    }

                    if (index != -1)
                    {
                        if(showMsBuildInfo)
                            Console.WriteLine("MsBuild auto-detection: using msbuild version '{0}' from '{1}'", max, subDirectories[index]);
                        return subDirectories[index];
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, ex.Message);
                }
            }
            return null;
        }

        // return 0 for success, return -1 for failure
        private static int DownloadAndInstallMsBuild()
        {
            var webClient = new WebClient();
            String toolName = "BuildTools_Full";
            int index = 0;
            while (File.Exists(toolName + index + ".exe"))
                index++;
            webClient.DownloadFile(ConfigurationManager.AppSettings["MsBuildDownloadInstallerUri"], toolName + index + ".exe");
            Process.Start(toolName + index + ".exe");
            return 0;
        }
    }
}