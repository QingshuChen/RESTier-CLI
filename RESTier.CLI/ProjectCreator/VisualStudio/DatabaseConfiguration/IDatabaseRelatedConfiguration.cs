using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.DatabaseConfiguration
{
    interface IDatabaseRelatedConfiguration
    {
        IProjectCreator ProjectCreator { get; set; }
        String ConnectionString { get; set; }
        bool AddDatabaseRelatedPackages();
        bool AddDatabaseModles();
        bool AddDatabaseConnectionString();
        bool AddDatabaseProvider();
        bool AddDatabaseRelatedCode();
    }
}
