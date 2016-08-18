using Microsoft.RESTier.Cli.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.CodeGeneration
{
    interface ICodeGenerator
    {
        IEnumerable<KeyValuePair<string, string>> generate(string connectionString, string projectName, string @namespace, DatabaseSetting dbSetting);
    }
}
