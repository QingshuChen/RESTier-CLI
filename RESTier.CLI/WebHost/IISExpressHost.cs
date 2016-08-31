using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.RESTier.Cli.DependencyResolver;
using System.Diagnostics;
using System.IO;

namespace Microsoft.RESTier.Cli.WebHost
{
    class IISExpressHost : IWebHost
    {
        IDependencyResolver _dependencyResolver;
        public IISExpressHost(IDependencyResolver dependencyResolver)
        {
            this._dependencyResolver = dependencyResolver;
        }
        public IDependencyResolver GetDependencyResolver()
        {
            return _dependencyResolver;
        }

        public bool Host(string projectDirectory)
        {
            var p = new Process();
            p.StartInfo.FileName = _dependencyResolver.Detect();
            if (string.IsNullOrEmpty(p.StartInfo.FileName))
            {
                return false;
            }
            string configFile = System.IO.Path.Combine(projectDirectory, @".vs\config\applicationhost.config");
            if (!File.Exists(configFile))
            {
                ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't find the configration file '{0}'" + configFile);
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = @"/config:" + configFile;
            p.Start();
            p.WaitForExit();
            return true;
        }
    }
}
