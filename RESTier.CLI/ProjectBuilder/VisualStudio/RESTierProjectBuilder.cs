using Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.TextTemplate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio
{
    class RESTierProjectBuilder : IProjectBuilder
    {
        private string _path;
        private IProjectBuilder _projectBuilder;
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

        public RESTierProjectBuilder(IProjectBuilder projectBuilder)
        {
            this._projectBuilder = projectBuilder;
            this.Name = projectBuilder.Name;
            this.Namespace = projectBuilder.Namespace;
            this._path = projectBuilder.Path;
        }

        public bool Create()
        {
            _projectBuilder.Create();
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
            string webApiConfigFile = _projectBuilder.Path + "\\" + _projectBuilder.Name + @"\App_Start\WebApiConfig.cs";
            if (!File.Exists(webApiConfigFile))
            {
                var fs = File.Create(webApiConfigFile);
                fs.Close();
            }
            StreamWriter streamwrite = new StreamWriter(webApiConfigFile);
            streamwrite.Write(new RESTierWebApiConfigFile(_projectBuilder.Name, _projectBuilder.Namespace).TransformText());
            streamwrite.Close();
            return true;
        }
        

        private bool addRESTierPackage()
        {
            string packageFile = _projectBuilder.Path + "\\" + _projectBuilder.Name + "\\packages.config";
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
