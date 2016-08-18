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
        void AddDatabaseRelatedPackages();
        void AddDatabaseModles();
        void AddDatabaseConnectionString();
        void AddDatabaseProvider();
        void AddDatabaseRelatedCode();
    }
}
