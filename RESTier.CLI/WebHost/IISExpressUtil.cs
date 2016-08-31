using Microsoft.RESTier.Cli.Uitls.DetectionUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.WebServerUtils
{
    class IISExpressUtil : WebServerUtil
    {
        public IISExpressUtil(DetectionUtil detectionUtil) : base(detectionUtil)
        {

        }
        public override bool Run(string projectDirectory)
        {
            var p = new Process();
            p.StartInfo.FileName = GetDetectionUtil().Detect();
            if (string.IsNullOrEmpty(p.StartInfo.FileName))
            {
                return false;
            }
            string configFile = System.IO.Path.Combine(projectDirectory, @".vs\config\applicationhost.config");
            if (!File.Exists(configFile))
            {
                ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find the configration file '{0}'" + configFile);
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = @"/config:" + configFile;
            p.Start();
            p.WaitForExit();
            return true;
        }
    }
}
