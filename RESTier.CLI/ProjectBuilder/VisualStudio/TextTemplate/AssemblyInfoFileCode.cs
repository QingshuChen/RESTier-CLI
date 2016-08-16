using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.TextTemplate
{
    partial class AssemblyInfoFile
    {
        private string projectName;
        public AssemblyInfoFile(string projectName)
        {
            this.projectName = projectName;
        }
    }
}
