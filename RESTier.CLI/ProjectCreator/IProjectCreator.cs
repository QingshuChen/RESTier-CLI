using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator
{
    public interface IProjectCreator
    {
        /// <summary>
        /// Create a project
        /// </summary>
        /// <returns>
        /// True for success, false for failure
        /// </returns>
        bool Create();
        /// <summary>
        /// The name for the project
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The namespace of the project
        /// </summary>
        string Namespace { get; set; }
        /// <summary>
        /// The path to store the project
        /// </summary>
        string Path { get; set; }
    }
}
