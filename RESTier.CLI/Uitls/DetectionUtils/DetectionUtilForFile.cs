using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.DetectionUtils
{
    class DetectionUtilForFile : DetectionUtil
    {
        public override string Detect()
        {
            if (File.Exists(System.IO.Path.Combine(Path, ExecutableFileName)))
            {
                return System.IO.Path.Combine(Path, ExecutableFileName);
            }
            return null;
        }
    }
}
