using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.TextTemplate
{
    partial class RESTierWebApiConfigFile
    {
        private string @namespace;
        private string projectName;

        public RESTierWebApiConfigFile(string projectName, string @namespace)
        {
            this.projectName = projectName;
            this.@namespace = @namespace;
        }
    }
}
