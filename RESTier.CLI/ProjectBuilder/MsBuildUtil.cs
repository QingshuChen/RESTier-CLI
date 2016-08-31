using Microsoft.RESTier.Cli.Uitls.DetectionUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.BuildUtils
{
    public class MsBuildUtil : BuildUtil
    {
        public MsBuildUtil(DetectionUtil detectionUtil) : base(detectionUtil) { }
        public override bool Build(string project, string buildSetting)
        {
            if (!NugetRestore(project))
                return false;
            var p = new Process();
            p.StartInfo.FileName = GetDetectionUtil().Detect();
            if (string.IsNullOrEmpty(p.StartInfo.FileName))
            {
                return false;
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = project +
                (string.IsNullOrEmpty(buildSetting) ? "" : " " + buildSetting);
            p.Start();
            p.WaitForExit();
            return true;
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
