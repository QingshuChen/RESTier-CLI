using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Commands
{
    internal class DatabaseTableOrView
    {
        public string catalogName { get; set; }
        public string schemaName { get; set; }
        public string tableOrViewName { get; set; }

        public DatabaseTableOrView(string catalogName, string schemaName, string name)
        {
            this.catalogName = catalogName;
            this.schemaName = schemaName;
            this.tableOrViewName = name;
        }
    }
}
