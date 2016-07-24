using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli
{
    public static class Extensions
    {
        public static string GetOptionValue(this CommandLineApplication command, string optionName)
        {
            return command.Options.FirstOrDefault(o => o.ShortName == optionName || o.LongName == optionName || o.SymbolName == optionName)?.Value();
        }
    }
}
