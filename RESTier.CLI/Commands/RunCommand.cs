using System;
using Microsoft.Extensions.CommandLineUtils;
using System.Diagnostics;
using System.IO;

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

            command.OnExecute(() =>
            {
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
                        ConsoleHelper.WriteError("Can't find solution: {0}", project.Value());
                        command.ShowHelp();
                        return 0;
                    }
                    int index1 = project.Value().LastIndexOf('/');
                    int index2 = project.Value().LastIndexOf('\\');
                    if (index1 == -1 && index2 == -1)
                    {
                        projectDirectory = Directory.GetCurrentDirectory();
                    }
                    else
                    {
                        projectDirectory = project.Value().Substring(0, (index1 > index2 ? index1 : index2));
                    }
                }
                
                // Set current directory to the directory that contains the RESTier Project
                Directory.SetCurrentDirectory(projectDirectory);
                if (!File.Exists(".vs\\config\\applicationhost.config"))
                {
                    Console.Write("Can't find the configration file '" + projectDirectory + "\\" + ".vs\\config\\applicationhost.config' \n" +
                        "Make sure you have set the correct project");
                    command.ShowHelp();
                    return 0;
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

            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c \"" + Config.IISExpressPath + "iisexpress.exe\" " +
                 "/config:" + ".vs\\config\\applicationhost.config";
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

        }
    }
}