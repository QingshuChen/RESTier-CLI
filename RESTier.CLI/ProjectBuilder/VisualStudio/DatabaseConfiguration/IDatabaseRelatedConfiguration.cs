using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.DatabaseConfiguration
{
    interface IDatabaseRelatedConfiguration
    {
        IProjectBuilder ProjectBuilder { get; set; }
        String ConnectionString { get; set; }
        bool AddDatabaseRelatedPackages();
        bool AddDatabaseModles();
        bool AddDatabaseConnectionString();
        bool AddDatabaseProvider();
        bool AddDatabaseRelatedCode();
    }
}
