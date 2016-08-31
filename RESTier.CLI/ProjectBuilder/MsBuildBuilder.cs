using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.RESTier.Cli.DependencyResolver;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Configuration;

namespace Microsoft.RESTier.Cli.ProjectBuilder
{
    class MsBuildBuilder : IProjectBuilder
    {
        private IDependencyResolver _dependencyResolver;
        public MsBuildBuilder(IDependencyResolver dependencyResolver)
        {
            this._dependencyResolver = dependencyResolver;
        }
        public bool Build(string project, string buildSetting)
        {
            string buildTool = _dependencyResolver.Detect();
            if (!File.Exists(project) || string.IsNullOrEmpty(buildTool))
            {
                return false;
            }
            if (!NugetRestore(project))
                return false;
            var p = new Process();
            p.StartInfo.FileName = buildTool;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = project +
                (string.IsNullOrEmpty(buildSetting) ? "" : " " + buildSetting);
            p.Start();
            p.WaitForExit();
            return true;
        }

        public IDependencyResolver GetDependencyResolver()
        {
            return _dependencyResolver;
        }

        private bool NugetRestore(string project)
        {
            try
            {
                // restore packages for the RESTier project
                if (!File.Exists("nuget.exe"))
                {
                    WebClient t = new WebClient();
                    t.DownloadFile(ConfigurationManager.AppSettings["NuGetClientURL"], "nuget.exe");
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine(ConsoleColor.Red, "Error when try to get 'nuget.exe' from '{0}'", ConfigurationManager.AppSettings["NuGetClientURL"]);
                ConsoleHelper.WriteLine(ConsoleColor.Red, ex.Message);
                return false;
            }
            Process p = new Process();
            p.StartInfo.FileName = "nuget.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = "restore " + project;
            p.Start();
            p.WaitForExit();
            return true;
        }
    }
}
