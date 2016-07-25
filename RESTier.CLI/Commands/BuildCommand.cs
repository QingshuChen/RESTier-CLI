using System;
using Microsoft.Extensions.CommandLineUtils;
using System.Diagnostics;
using System.IO;

namespace Microsoft.RESTier.Cli.Commands
{
    public class BuildCommand
    {
        public static void Configure(CommandLineApplication command)
        {
            command.Description = "Builds the RESTier project.";
            command.HelpOption("--help");

            var projectName = command.Option("-p|--project", "The name for the RESTier project", CommandOptionType.SingleValue);
            var buildSetting = command.Option("-s|--build-setting",
               "Parameter for the msbuild when complile the project",
               CommandOptionType.SingleValue);

            command.OnExecute(() =>
            {
                string pName = "";
                if (string.IsNullOrEmpty(projectName.Value()))
                {
                    string dir = Directory.GetCurrentDirectory();
                    DirectoryInfo sDir = new DirectoryInfo(dir);
                    FileInfo[] fileArray = sDir.GetFiles();
                    foreach (FileInfo file in fileArray)
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
                }

                if (pName.Length == 0)
                {
                    Console.Write("Can't find a project to build");
                    command.ShowHelp();
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

            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.Arguments = "/c " + Config.MSBuildPath + "MSBuild.exe " + projectName +
                (string.IsNullOrEmpty(buildSetting) ? "" : " " + buildSetting);

            p.Start();

            p.WaitForExit();
        }

        // Ignore the last line that contains the word "exit"
        // Used to delete the output when execute "exit" command
        private static string ignoreLastLineContainWordExit(string str)
        {
            int index = str.LastIndexOf('\n', str.LastIndexOf("exit"));
            if (index < 0) // unlikely to happen
                return str;
            return str.Substring(0, index);
        }
    }
}