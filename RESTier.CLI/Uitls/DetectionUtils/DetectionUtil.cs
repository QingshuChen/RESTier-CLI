using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.Uitls.DetectionUtils
{
    public abstract class DetectionUtil
    {
        /// <summary>
        /// name for the software
        /// </summary>
        public string SoftwareName { get; set; }
        /// <summary>
        /// name for the executable file of the software
        /// </summary>
        public string ExecutableFileName { get; set; }
        /// <summary>
        /// path for the software
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// URL to get the instruction of the software
        /// </summary>
        public string DownloadInstructionsUri { get; set; }
        /// <summary>
        /// URL to download the software installer
        /// </summary>
        public string DownloadInstallerUri { get; set; }

        private int _index;
        /// <summary>
        /// detect whether the software has been installed
        /// </summary>
        /// <returns>
        /// return null if the software doesn't exist, else ruturn the path to the software
        /// </returns>
        public abstract string Detect();

        /// <summary>
        /// download the software
        /// </summary>
        /// <returns></returns>
        public bool Download()
        {
            var webClient = new WebClient();
            while (File.Exists(SoftwareName + _index + ".exe"))
                _index++;
            webClient.DownloadFile(DownloadInstallerUri, SoftwareName + _index + ".exe");
            return true;
        }

        /// <summary>
        /// install the software
        /// </summary>
        public void Install()
        {
            if (File.Exists(SoftwareName + _index + ".exe"))
                Process.Start(SoftwareName + _index + ".exe");
            else
            {
                var webClient = new WebClient();
                webClient.DownloadFile(DownloadInstallerUri, SoftwareName + _index + ".exe");
                Process.Start(SoftwareName + _index + ".exe");
            }
        }
    }
}
