using Microsoft.RESTier.Cli.DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectBuilder
{
    interface IProjectBuilder
    {
        /// <summary>
        /// Build the project
        /// </summary>
        /// <param name="project">The project to build</param>
        /// <returns>
        /// return true for success
        /// return false for failure
        /// </returns>
        bool Build(string project, string buildSetting);

        /// <summary>
        /// Return the dependency resolver
        /// </summary>
        /// <returns></returns>
        IDependencyResolver GetDependencyResolver();
    }
}
