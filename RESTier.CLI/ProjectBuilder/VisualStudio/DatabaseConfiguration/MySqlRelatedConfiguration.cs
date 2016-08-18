using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.DatabaseConfiguration
{
    internal class MySqlRelatedConfiguration : IDatabaseRelatedConfiguration
    {
        public string ConnectionString { get; set; }

        public IProjectBuilder ProjectBuilder { get; set; }
        public bool AddDatabaseConnectionString()
        {
            throw new NotImplementedException();
        }

        public bool AddDatabaseModles()
        {
            throw new NotImplementedException();
        }

        public bool AddDatabaseProvider()
        {
            throw new NotImplementedException();
        }

        public bool AddDatabaseRelatedCode()
        {
            throw new NotImplementedException();
        }

        public bool AddDatabaseRelatedPackages()
        {
            throw new NotImplementedException();
        }
    }
}
