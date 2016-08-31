using Microsoft.RESTier.Cli.DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.WebHost
{
    interface IWebHost
    {
        /// <summary>
        /// Host the project
        /// </summary>
        /// <param name="project">The directory that contains the project to host</param>
        /// <returns>
        /// return true for success
        /// return false for failure
        /// </returns>
        bool Host(string projectDirectory);

        /// <summary>
        /// Return the dependency resolver
        /// </summary>
        /// <returns></returns>
        IDependencyResolver GetDependencyResolver();
    }
}
