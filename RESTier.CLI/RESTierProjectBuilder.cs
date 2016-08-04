using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using Microsoft.RESTier.Cli.TextTemplate;
using System.Configuration;
using System;

namespace Microsoft.RESTier.Cli
{
    /// <summary>
    /// Build an .NET Web Application Projcet which support a standardized, 
    /// OData V4 based RESTful services on .NET platform from a connection string
    /// </summary>
    class RESTierProjectBuilder
    {
        // Path for the newly-build project
        private readonly string projectPath;
        // Name of the newly-build project
        private readonly string projectName;
        // the connection string of the database which gonna create a OData V4 based RESTful services
        private readonly string connectionString;
        // The namespace for the new RESTier project
        private readonly string @namespace;

        public RESTierProjectBuilder(string connection, string projectName, string @namespace)
        {
            this.connectionString = connection;
            this.projectName = projectName;
            this.@namespace = @namespace;
            this.projectPath = Directory.GetCurrentDirectory() + "\\" + projectName;
        }

        // Create the folders for the .Net Web Applications
        private bool CreateFolders()
        {
            if (Directory.Exists(projectPath))
            {
                if (Directory.GetDirectories(projectPath).Length > 0 || Directory.GetFiles(projectPath).Length > 0)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't create RESTier API in {0}, the diretory exists and is not empty.", projectPath);
                    return false;
                }
            }
            else
            {
                Directory.CreateDirectory(projectPath);
            }
            Directory.CreateDirectory(projectPath + "\\.vs");
            Directory.CreateDirectory(projectPath + "\\.vs\\config");
            Directory.CreateDirectory(projectPath + "\\packages");
            Directory.CreateDirectory(projectPath + "\\" + projectName);
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\App_Data");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\App_Start");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\bin");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\Controllers");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\Models");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\obj");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\Properties");
            Directory.CreateDirectory(projectPath + "\\" + projectName + "\\scripts");
            return true;
        }

        // Create a file that contains specific content
        private void CreateFile(string filename, string content)
        {
            var fs = File.Create(filename);
            fs.Close();
            StreamWriter sw = new StreamWriter(filename, false);
            sw.WriteLine(content);
            sw.Close();
        }

        // Create solution file for the C# project
        private void CreateSolutionFile()
        {
            string filename = projectPath + "\\" + projectName + ".sln";
            SolutionFile solutionFile = new SolutionFile(projectName);
            CreateFile(filename, solutionFile.TransformText());
        }
        // Create applicationhost.config file for the IIS Express
        private void CreateApplicationhostConfigFile()
        {
            string filename = projectPath + @"\.vs\config\applicationhost.config";
            ApplicationhostConfigFile template = new ApplicationhostConfigFile(projectName, projectPath + @"\" + projectName);
            CreateFile(filename, template.TransformText());
        }

        private void CreateWebApiConfigFile()
        {
            string filename = projectPath + "\\" + projectName + @"\App_Start\WebApiConfig.cs";
            WebApiConfigFile template = new WebApiConfigFile(projectName, @namespace);
            CreateFile(filename, template.TransformText());
        }

        private void CreateAssemblyInfoFile()
        {
            string filename = projectPath + "\\" + projectName + @"\Properties\AssemblyInfo.cs";
            AssemblyInfoFile template = new AssemblyInfoFile(projectName);
            CreateFile(filename, template.TransformText());
        }

        private void CreateAiJSFile()
        {
            string filename = projectPath + "\\" + projectName + @"\scripts\ai.0.22.9-build00167.js";
            CreateFile(filename, new AiJsFile().TransformText());
        }

        private void CreateAiJSMinFile()
        {
            string filename = projectPath + "\\" + projectName + @"\scripts\ai.0.22.9-build00167.min.js";
            CreateFile(filename, new AiJsMinFile().TransformText());
        }

        private void CreateApplicationInsightsConfigFile()
        {
            string filename = projectPath + "\\" + projectName + @"\ApplicationInsights.config";
            CreateFile(filename, new ApplicationInsightsConfigFile().TransformText());
        }

        private void CreateGlobalAsaxFile()
        {
            string filename = projectPath + "\\" + projectName + @"\Global.asax";
            CreateFile(filename, new GlobalAsaxFile(@namespace).TransformText());
        }

        private void CreateGlobalAsaxCSFile()
        {
            string filename = projectPath + "\\" + projectName + @"\Global.asax.cs";
            CreateFile(filename, new GlobalAsaxCSFile(@namespace).TransformText());
        }

        private void CreatePackagesConfigFile()
        {
            string filename = projectPath + "\\" + projectName + @"\packages.config";
            CreateFile(filename, new PackagesConfigFile().TransformText());
        }

        private void CreateCSPROJFile()
        {
            string filename = projectPath + "\\" + projectName + @"\" + projectName + ".csproj";
            CreateFile(filename, new CSPROJFile(projectName).TransformText()) ;
        }

        private void CreateCSPROJUserFile()
        {
            string filename = projectPath + "\\" + projectName + @"\" + projectName + ".csproj.user";
            CreateFile(filename, new CSPROJUserFile().TransformText());
        }

        private void CreateWebConfigFile()
        {
            string filename = projectPath + "\\" + projectName + @"\Web.config";
            CreateFile(filename, new WebConfigFile(projectName, connectionString).TransformText());
        }

        private void CreateWebDebugConfigFile()
        {
            string filename = projectPath + "\\" + projectName + @"\Web.Debug.config";
            CreateFile(filename, new WebDebugConfigFile().TransformText());
        }


        private void CreateWebReleaseConfigFile()
        {
            string filename = projectPath + "\\" + projectName + @"\Web.Release.config";
            CreateFile(filename, new WebReleaseConfigFile().TransformText());
        }


        /// <summary>
        /// Generate an .NET Web Application Projcet which support a standardized, 
        /// OData V4 based RESTful services on .NET platform from a connection string
        /// </summary>
        /// <returns>reuturn 0 for success, -1 for failure</returns>
        public int Generate()
        {
            var engine = new CodeGenerationEngine(connectionString, projectName, @namespace);
            var tableClasses = engine.GenerateCode();
            if (tableClasses == null)
            {
                return -1;
            }
            else
            {
                if (!CreateFolders())
                {
                    return -1;
                }
                CreateSolutionFile();
                CreateApplicationhostConfigFile();
                CreateWebApiConfigFile();
                CreateAssemblyInfoFile();
                CreateAiJSFile();
                CreateAiJSMinFile();
                CreateApplicationInsightsConfigFile();
                CreateGlobalAsaxFile();
                CreateGlobalAsaxCSFile();
                CreatePackagesConfigFile();
                CreateCSPROJFile();
                CreateCSPROJUserFile();
                CreateWebConfigFile();
                CreateWebDebugConfigFile();
                CreateWebReleaseConfigFile();

                AddModleFile(tableClasses);
                // restore packages for the RESTier project
                try
                {
                    WebClient t = new WebClient();
                    t.DownloadFile(ConfigurationManager.AppSettings["NuGetClientURL"], "nuget.exe");
                    CmdNugetRestore(projectPath + "\\" + projectName + @".sln");
                }
                catch (Exception ex)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Error when try to get 'nuget.exe' from '{0}'", ConfigurationManager.AppSettings["NuGetClientURL"]);
                    ConsoleHelper.WriteLine(ConsoleColor.Red, ex.Message);
                    return -1;
                }
                
                return 0;
            }
        }

        private void CmdNugetRestore(string projectName)
        {
            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = "/c " + "nuget.exe restore " + projectName; 

            p.Start();
            p.WaitForExit();
        }

        // To add files to the cs project, we need to update the .csproj file
        private bool AddModelFileItemInCSPROJFile(IEnumerable<KeyValuePair<string, string>> modelFiles)
        {
            string CSPROJFileName = projectPath + "\\" + projectName + "\\" + projectName + ".csproj";
            if (!File.Exists(CSPROJFileName))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(CSPROJFileName);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("Project").Item(0);
            XmlElement ItemGroupNode = doc.CreateElement("ItemGroup", node.NamespaceURI);
            foreach (var file in modelFiles)
            {
                XmlElement CompileNode = doc.CreateElement("Compile", node.NamespaceURI);
                CompileNode.SetAttribute("Include", "Models\\" + file.Key);
                ItemGroupNode.AppendChild(CompileNode);
            }

            node.AppendChild(ItemGroupNode);
            doc.Save(CSPROJFileName);
            return true;
        }

        // Generate the files in the Modles directory
        private bool AddModleFile(IEnumerable<KeyValuePair<string, string>> modelFiles)
        {
            FileStream fs;
            StreamWriter streamwrite;
            string modelDirPath = projectPath + "\\" + projectName + "\\Models\\";
            foreach (var file in modelFiles)
            {
                fs = File.Create(modelDirPath + file.Key);
                fs.Close();
                streamwrite = new StreamWriter(modelDirPath + file.Key);
                streamwrite.Write(file.Value);
                streamwrite.Close();
            }
            AddModelFileItemInCSPROJFile(modelFiles);
            return true;
        }
    }
    
    

}
