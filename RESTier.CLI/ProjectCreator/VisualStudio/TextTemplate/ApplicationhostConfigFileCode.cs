using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate
{
    partial class ApplicationhostConfigFile
    {
        private string projectName;
        private string projectPath;

        public ApplicationhostConfigFile(string projectName, string projectPath)
        {
            this.projectName = projectName;
            this.projectPath = projectPath;
        }
    }
}
