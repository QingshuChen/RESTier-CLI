using Microsoft.RESTier.Cli.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.DatabaseConfiguration
{
    class DatabaseRelatedConfigurationFactory
    {
        public static IDatabaseRelatedConfiguration Create(DatabaseType type)
        {
            if (type == DatabaseType.SQLServer)
            {
                return new SQLServerRelatedConfiguration();
            }
            else if (type == DatabaseType.MYSQL)
            {
                return new MySqlRelatedConfiguration();
            }
            else
            {
                return null;
            }
        }
    }
}
