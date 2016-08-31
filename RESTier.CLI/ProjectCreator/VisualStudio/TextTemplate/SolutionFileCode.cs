using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate
{
    partial class SolutionFile
    {
        private string projectName;
        public SolutionFile(string projectName)
        {
            this.projectName = projectName;
        }
    }
}
