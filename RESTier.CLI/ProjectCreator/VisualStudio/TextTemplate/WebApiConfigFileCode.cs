using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate
{
    partial class WebApiConfigFile
    {
        private string @namespace;
        private string projectName;

        public WebApiConfigFile(string projectName, string @namespace)
        {
            this.projectName = projectName;
            this.@namespace = @namespace;
        }
    }
}
