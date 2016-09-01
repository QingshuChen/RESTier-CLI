using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Database
{
    public class DatabaseSetting
    {
        public string Name { get; set; }
        public DatabaseType DBType { get; set; }
        public string ProviderInvariantName { get; set; }
        public string ProviderType { get; set; }
        public ArrayList Packages { get; set; }
        public ArrayList References { get; set; }
    }
}
