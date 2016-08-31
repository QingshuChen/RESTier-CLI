using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.DependencyResolver
{
    interface IDependencyResolver
    {
        /// <summary>
        /// name for the software
        /// </summary>
        string GetSoftwareName();
        /// <summary>
        /// name for the executable file of the software
        /// </summary>
        string GetExecutableFileName();
        /// <summary>
        /// path for the software
        /// </summary>
        string GetPath();
        /// <summary>
        /// URL to get the instruction of the software
        /// </summary>
        string GetDownloadInstructionsUri();
        /// <summary>
        /// URL to download the software installer
        /// </summary>
        string GetDownloadInstallerUri();
        /// <summary>
        /// detect whether the software has existed
        /// </summary>
        /// <returns>
        /// return path of the software,
        /// return null if the software doesn't exist
        /// </returns>
        string Detect();
        /// <summary>
        /// Download the software
        /// </summary>
        /// <returns>path to the download file, null for download failure</returns>
        string Download();
        /// <summary>
        /// install the software
        /// </summary>
        void Install();
    }
}
