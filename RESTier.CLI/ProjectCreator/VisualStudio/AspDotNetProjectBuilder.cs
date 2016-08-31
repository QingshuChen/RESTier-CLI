using Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio
{
    internal class AspDotNetProjectCreator : IProjectCreator
    {
        private string _path;
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Path
        {
            get
            {
                return this._path;
            }
            set
            {
                this._path = System.IO.Path.Combine(value, this.Name);
            }
        }
        /// <summary>
        /// Create an empty asp.net vs project
        /// </summary>
        /// <param name="name">project name</param>
        /// <param name="namespace">namespace for the project</param>
        /// <param name="path">path to store the project</param>
        public AspDotNetProjectCreator(string name, string @namespace, string path)
        {
            this.Name = name;
            this.Namespace = @namespace;
            this._path = System.IO.Path.Combine(path, name);
        }
            

        public bool Create()
        {
            if (!CreateFolders())
            {
                return false;
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
            CreateWebConfigFile();
            CreateWebDebugConfigFile();
            CreateWebReleaseConfigFile();
            return true;
        }

        // Create the folders for the .Net Web Applications
        private bool CreateFolders()
        {
            if (Directory.Exists(Path))
            {
                if (Directory.GetDirectories(Path).Length > 0 || Directory.GetFiles(Path).Length > 0)
                {
                    ConsoleHelper.WriteLine(ConsoleColor.Red, "Can't create project in {0}, the diretory exists and is not empty.", Path);
                    return false;
                }
            }
            else
            {
                Directory.CreateDirectory(Path);
            }
            Directory.CreateDirectory(Path + "\\.vs");
            Directory.CreateDirectory(Path + "\\.vs\\config");
            Directory.CreateDirectory(Path + "\\packages");
            Directory.CreateDirectory(Path + "\\" + Name);
            Directory.CreateDirectory(Path + "\\" + Name + "\\App_Data");
            Directory.CreateDirectory(Path + "\\" + Name + "\\App_Start");
            Directory.CreateDirectory(Path + "\\" + Name + "\\bin");
            Directory.CreateDirectory(Path + "\\" + Name + "\\Controllers");
            Directory.CreateDirectory(Path + "\\" + Name + "\\Models");
            Directory.CreateDirectory(Path + "\\" + Name + "\\obj");
            Directory.CreateDirectory(Path + "\\" + Name + "\\Properties");
            Directory.CreateDirectory(Path + "\\" + Name + "\\scripts");
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
            string filename = Path + "\\" + Name + ".sln";
            SolutionFile solutionFile = new SolutionFile(Name);
            CreateFile(filename, solutionFile.TransformText());
        }
        // Create applicationhost.config file for the IIS Express
        private void CreateApplicationhostConfigFile()
        {
            string filename = Path + @"\.vs\config\applicationhost.config";
            ApplicationhostConfigFile template = new ApplicationhostConfigFile(Name, Path + @"\" + Name);
            CreateFile(filename, template.TransformText());
        }

        private void CreateWebApiConfigFile()
        {
            string filename = Path + "\\" + Name + @"\App_Start\WebApiConfig.cs";
            WebApiConfigFile template = new WebApiConfigFile(Name, Namespace);
            CreateFile(filename, template.TransformText());
        }

        private void CreateAssemblyInfoFile()
        {
            string filename = Path + "\\" + Name + @"\Properties\AssemblyInfo.cs";
            AssemblyInfoFile template = new AssemblyInfoFile(Name);
            CreateFile(filename, template.TransformText());
        }

        private void CreateAiJSFile()
        {
            string filename = Path + "\\" + Name + @"\scripts\ai.0.22.9-build00167.js";
            CreateFile(filename, new AiJsFile().TransformText());
        }

        private void CreateAiJSMinFile()
        {
            string filename = Path + "\\" + Name + @"\scripts\ai.0.22.9-build00167.min.js";
            CreateFile(filename, new AiJsMinFile().TransformText());
        }

        private void CreateApplicationInsightsConfigFile()
        {
            string filename = Path + "\\" + Name + @"\ApplicationInsights.config";
            CreateFile(filename, new ApplicationInsightsConfigFile().TransformText());
        }

        private void CreateGlobalAsaxFile()
        {
            string filename = Path + "\\" + Name + @"\Global.asax";
            CreateFile(filename, new GlobalAsaxFile(Namespace).TransformText());
        }

        private void CreateGlobalAsaxCSFile()
        {
            string filename = Path + "\\" + Name + @"\Global.asax.cs";
            CreateFile(filename, new GlobalAsaxCSFile(Namespace).TransformText());
        }

        private void CreatePackagesConfigFile()
        {
            string filename = Path + "\\" + Name + @"\packages.config";
            CreateFile(filename, new PackagesConfigFile().TransformText());
        }

        private void CreateCSPROJFile()
        {
            string filename = Path + "\\" + Name + @"\" + Name + ".csproj";
            CreateFile(filename, new CSPROJFile(Name).TransformText());
        }


        private void CreateWebConfigFile()
        {
            string filename = Path + "\\" + Name + @"\Web.config";
            CreateFile(filename, new WebConfigFile().TransformText());
        }

        private void CreateWebDebugConfigFile()
        {
            string filename = Path + "\\" + Name + @"\Web.Debug.config";
            CreateFile(filename, new WebDebugConfigFile().TransformText());
        }


        private void CreateWebReleaseConfigFile()
        {
            string filename = Path + "\\" + Name + @"\Web.Release.config";
            CreateFile(filename, new WebReleaseConfigFile().TransformText());
        }
    }
}
