using Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.TextTemplate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio
{
    class RESTierProjectCreator : IProjectCreator
    {
        private string _path;
        private IProjectCreator _projectCreator;
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

        public RESTierProjectCreator(IProjectCreator ProjectCreator)
        {
            this._projectCreator = ProjectCreator;
            this.Name = ProjectCreator.Name;
            this.Namespace = ProjectCreator.Namespace;
            this._path = ProjectCreator.Path;
        }

        public bool Create()
        {
            if (!_projectCreator.Create())
                return false;
            if (!addRESTierPackage())
                return false;
            if (!updateWebApiConfig())
                return false;
            return true;
        }

        private ArrayList getPackages()
        {
            ArrayList list = new ArrayList();
            list.Add(new Tuple<string, string, string>("Microsoft.Restier", "0.5.0-beta", "net452"));
            list.Add(new Tuple<string, string, string>("Microsoft.Restier.Core", "0.5.0-beta", "net452"));
            list.Add(new Tuple<string, string, string>("Microsoft.Restier.Providers.EntityFramework", "0.5.0-beta", "net452"));
            list.Add(new Tuple<string, string, string>("Microsoft.Restier.Publishers.OData", "0.5.0-beta", "net452"));
            return list;
        }

        private bool updateWebApiConfig()
        {
            string webApiConfigFile = _projectCreator.Path + "\\" + _projectCreator.Name + @"\App_Start\WebApiConfig.cs";
            if (!File.Exists(webApiConfigFile))
            {
                var fs = File.Create(webApiConfigFile);
                fs.Close();
            }
            StreamWriter streamwrite = new StreamWriter(webApiConfigFile);
            streamwrite.Write(new RESTierWebApiConfigFile(_projectCreator.Name, _projectCreator.Namespace).TransformText());
            streamwrite.Close();
            return true;
        }
        

        private bool addRESTierPackage()
        {
            string packageFile = _projectCreator.Path + "\\" + _projectCreator.Name + "\\packages.config";
            if (!File.Exists(packageFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(packageFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("packages").Item(0);
            foreach (Tuple<string, string, string> item in getPackages())
            {
                XmlElement packageNode = doc.CreateElement("package", node.NamespaceURI);
                packageNode.SetAttribute("id", item.Item1);
                packageNode.SetAttribute("version", item.Item2);
                packageNode.SetAttribute("targetFramework", item.Item1);
                node.AppendChild(packageNode);
            }
            doc.Save(packageFile);
            return true;
        }
    }
}
