using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.DependencyResolver
{
    class IISExpressResolver : IDependencyResolver
    {
        private int _index = 0;
        public string Detect()
        {
            string fileName = GetPath() + GetExecutableFileName();
            if (!File.Exists(fileName))
                return null;
            return fileName;
        }

        public string Download()
        {
            var webClient = new WebClient();
            while (File.Exists(GetSoftwareName() + _index + ".exe"))
                _index++;
            try
            {
                webClient.DownloadFile(GetDownloadInstallerUri(), GetSoftwareName() + _index + ".exe");
                return GetSoftwareName() + _index + ".exe";
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't download " + GetSoftwareName() + "\n" + ex.Message);
                return null;
            }
           
        }

        public string GetDownloadInstallerUri()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return ConfigurationManager.AppSettings["IISExpressDownloadInstaller64Uri"];
            }
            else
            {
                return ConfigurationManager.AppSettings["IISExpressDownloadInstaller32Uri"];
            }
        }

        public string GetDownloadInstructionsUri()
        {
            return ConfigurationManager.AppSettings["IISExpressDownloadInstructionsUri"];
        }

        public string GetExecutableFileName()
        {
            return "iisexpress.exe";
        }

        public string GetPath()
        {
            return ConfigurationManager.AppSettings["IISExpressPath"];
        }

        public string GetSoftwareName()
        {
            return "IISExpress";
        }

        public void Install()
        {
            if (File.Exists(GetSoftwareName() + _index + ".exe"))
                Process.Start(GetSoftwareName() + _index + ".exe");
            else
            {
                var webClient = new WebClient();
                webClient.DownloadFile(GetDownloadInstallerUri(), GetSoftwareName() + _index + ".exe");
                Process.Start(GetSoftwareName() + _index + ".exe");
            }
        }
    }
}
