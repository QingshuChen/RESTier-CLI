using Microsoft.RESTier.Cli.Uitls.DetectionUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.BuildUtils
{
    public class MsBuildUtil : BuildUtil
    {
        public MsBuildUtil(DetectionUtil detectionUtil) : base(detectionUtil) { }
        public override bool Build(string project, string buildSetting)
        {
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
    }
}
