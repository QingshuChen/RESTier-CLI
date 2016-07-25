using System.Linq;
using Microsoft.Extensions.CommandLineUtils;

namespace Microsoft.RESTier.Cli
{
    public static class Extensions
    {
        public static string GetOptionValue(this CommandLineApplication command, string optionName)
        {
            return
                command.Options.FirstOrDefault(
                    o => o.ShortName == optionName || o.LongName == optionName || o.SymbolName == optionName)?.Value();
        }
    }
}