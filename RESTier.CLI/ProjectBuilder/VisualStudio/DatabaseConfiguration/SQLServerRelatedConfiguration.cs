using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.DatabaseConfiguration
{
    internal class SQLServerRelatedConfiguration : IDatabaseRelatedConfiguration
    {
        public IProjectBuilder ProjectBuilder { get; set; }

        public void AddDatabaseConnectionString()
        {
            throw new NotImplementedException();
        }

        public void AddDatabaseModles()
        {
            throw new NotImplementedException();
        }

        public void AddDatabaseProvider()
        {
            throw new NotImplementedException();
        }

        public void AddDatabaseRelatedCode()
        {
            throw new NotImplementedException();
        }

        public void AddDatabaseRelatedPackages()
        {
            throw new NotImplementedException();
        }
    }
}
