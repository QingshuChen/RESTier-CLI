using Microsoft.RESTier.Cli.Uitls.DetectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.BuildUtils
{
    public abstract class BuildUtil
    {
        private DetectionUtil _detectionUtil;
        public BuildUtil(DetectionUtil detectionUtil)
        {
            this._detectionUtil = detectionUtil;
        }
        public abstract bool Build(string project, string buildSetting);

        public DetectionUtil GetDetectionUtil()
        {
            return _detectionUtil;
        }
    }
}
