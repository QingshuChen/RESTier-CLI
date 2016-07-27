using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;

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
            var buildSetting = command.Option("-s|--build-setting",
                "Build setting for MSBuild",
                CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                var pName = "";
                if (string.IsNullOrEmpty(projectName.Value()))
                {
                    var dir = Directory.GetCurrentDirectory();
                    var sDir = new DirectoryInfo(dir);
                    var fileArray = sDir.GetFiles();
                    foreach (var file in fileArray)
                    {
                        if (file.Extension.Equals("sln"))
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

                CmdMSBuild(pName, buildSetting.Value());

                Console.WriteLine("Built {0} successfully.", command.GetOptionValue("p"));
                return 0;
            });
        }

        // execute the msbuild to build a project
        private static void CmdMSBuild(string projectName, string buildSetting)
        {
            var p = new Process();

            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.Arguments = "/c " + "\"" + ConfigurationManager.AppSettings["msbuild"] + "\" " + projectName +
                (string.IsNullOrEmpty(buildSetting) ? "" : " " + buildSetting);

            p.Start();

            p.WaitForExit();
        }
    }
}