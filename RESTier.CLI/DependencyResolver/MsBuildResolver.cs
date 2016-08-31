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
    class DetectionUtilInDirectoryForDifferentVersion : IDependencyResolver
    {
        private int _index = 0;
        public string Detect()
        {
            if (Directory.Exists(GetPath()))
            {
                try
                {
                    double max = 0;
                    double version;
                    int index = -1;
                    string[] subDirectories = Directory.GetDirectories(GetPath());
                    for (int i = 0; i < subDirectories.Length; i++)
                    {
                        try
                        {
                            version = Convert.ToDouble(subDirectories[i].Substring(GetPath().Length));
                            if (version > max)
                            {
                                if (File.Exists(System.IO.Path.Combine(subDirectories[i], GetExecutableFileName())))
                                {
                                    max = version;
                                    index = i;
                                }
                            }
                        }
                        catch
                        {
                            // ignore the exception
                        }
                    }

                    if (index != -1)
                    {
                        return System.IO.Path.Combine(subDirectories[index], GetExecutableFileName());
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, ex.Message);
                }
            }
            return null;
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
            return ConfigurationManager.AppSettings["MsBuildDownloadInstallerUri"];
        }

        public string GetDownloadInstructionsUri()
        {
            return ConfigurationManager.AppSettings["MsBuildDownloadInstructionsUri"];
        }

        public string GetExecutableFileName()
        {
            return @"bin\MSBuild.exe";
        }

        public string GetPath()
        {
            return ConfigurationManager.AppSettings["MsBuildDirectory"];
        }

        public string GetSoftwareName()
        {
            return "MSBuild";
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
