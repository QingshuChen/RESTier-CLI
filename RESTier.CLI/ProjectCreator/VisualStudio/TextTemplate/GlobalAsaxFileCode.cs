using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate
{
    partial class GlobalAsaxFile
    {
        public string @namespace;
        public GlobalAsaxFile(string @namespace)
        {
            this.@namespace = @namespace;
        }
    }
}
