using Microsoft.RESTier.Cli.Uitls.DetectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.WebServerUtils
{
    public abstract class WebServerUtil
    {
        private DetectionUtil _detectionUtil;
        public WebServerUtil(DetectionUtil detectionUtil)
        {
            this._detectionUtil = detectionUtil;
        }
        public abstract bool Run(string project);

        public DetectionUtil GetDetectionUtil()
        {
            return _detectionUtil;
        }
    }
}
