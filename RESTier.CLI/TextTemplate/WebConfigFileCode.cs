using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.TextTemplate
{
    partial class WebConfigFile
    {
        private string projectName;
        private string connectionString;
        public WebConfigFile(string projectName, string connectionString)
        {
            this.projectName = projectName;
            this.connectionString = connectionString;
        }
    }
}
