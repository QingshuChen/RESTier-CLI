using Microsoft.RESTier.Cli.Database;
using Microsoft.RESTier.Cli.ProjectCreator.CodeGeneration;
using Microsoft.RESTier.Cli.ProjectCreator.CodeGeneration.EFCodeGeneration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio
{
    internal class DatabaseModelProjectCreator : IProjectCreator
    {
        private string _path;
        private string _connectionString;
        private IProjectCreator _projectCreator;
        private DatabaseSetting _dbSetting;
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

        public DatabaseModelProjectCreator(IProjectCreator projectCreator, DatabaseSetting dbSetting, String connectionString)
        {
            this._projectCreator = projectCreator;
            this._dbSetting = dbSetting;
            this.Name = projectCreator.Name;
            this.Namespace = projectCreator.Namespace;
            this._path = projectCreator.Path;
            this._connectionString = connectionString;
        }

        public bool Create()
        {
            if(!_projectCreator.Create())
                return false;
            if (!addDatabaseRelatedPackages())
                return false;
            if (!addDatabaseProvider())
                return false;
            if (!addDatabaseModel())
                return false;
            if (!addDatabaseConnectionString())
                return false;
            return true;
        }

        private bool addDatabaseModel()
        {
            ICodeGenerator codeGenerator = new EFCodeGenerator();
            var result = codeGenerator.generate(_connectionString, Name, Namespace, _dbSetting);
            if (result == null)
                return false;
            FileStream fs;
            StreamWriter streamwrite;
            string modelDirPath = this._path + "\\" + this.Name + "\\Models\\";
            foreach (var file in result)
            {
                fs = File.Create(modelDirPath + file.Key);
                fs.Close();
                streamwrite = new StreamWriter(modelDirPath + file.Key);
                streamwrite.Write(file.Value);
                streamwrite.Close();
            }
            return addModelFileItemInCSPROJFile(result);
        }

        public bool addDatabaseRelatedPackages()
        {
            // update package.config file
            string packageFile = this.Path + "\\" + this.Name + "\\packages.config";
            if (!File.Exists(packageFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(packageFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("packages").Item(0);
            foreach (Tuple<string, string, string> item in this._dbSetting.Packages)
            {
                XmlElement packageNode = doc.CreateElement("package", node.NamespaceURI);
                packageNode.SetAttribute("id", item.Item1);
                packageNode.SetAttribute("version", item.Item2);
                packageNode.SetAttribute("targetFramework", item.Item1);
                node.AppendChild(packageNode);
            }
            doc.Save(packageFile);

            // update .csproj file
            string csprojFile = this.Path + "\\" + this.Name + "\\" + this.Name + ".csproj";
            doc.Load(csprojFile);
            node = (XmlElement)doc.GetElementsByTagName("ItemGroup").Item(0);
            foreach (Tuple<string, string, string> item in this._dbSetting.References)
            {
                XmlElement referenceNode = doc.CreateElement("Reference", node.NamespaceURI);
                referenceNode.SetAttribute("Include", item.Item1);
                XmlElement hintPathNode = doc.CreateElement("HintPath", node.NamespaceURI);
                hintPathNode.InnerText = item.Item2;
                if (!string.IsNullOrEmpty(item.Item2))
                {
                    referenceNode.AppendChild(hintPathNode);
                }

                XmlElement privateNode = doc.CreateElement("Private", node.NamespaceURI);
                privateNode.InnerText = item.Item3;
                if (!string.IsNullOrEmpty(item.Item3))
                {
                    referenceNode.AppendChild(privateNode);
                }
                node.AppendChild(referenceNode);
            }
            doc.Save(csprojFile);
            return true;
        }

        public bool addDatabaseConnectionString()
        {
            string webConfigFile = this.Path + "\\" + this.Name + @"\Web.config";
            if (!File.Exists(webConfigFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(webConfigFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("configuration").Item(0);
            if (node == null)
                return false;
            XmlElement connectionStringNode = doc.CreateElement("connectionStrings", node.NamespaceURI);
            XmlElement addNode = doc.CreateElement("add", node.NamespaceURI);
            addNode.SetAttribute("name", this.Name);
            addNode.SetAttribute("connectionString", this._connectionString);
            addNode.SetAttribute("providerName", this._dbSetting.ProviderInvariantName);
            connectionStringNode.AppendChild(addNode);
            node.AppendChild(connectionStringNode);
            doc.Save(webConfigFile);
            return true;
        }

        private bool addDatabaseProvider()
        {
            string webConfigFile = this.Path + "\\" + this.Name + @"\Web.config";
            if (!File.Exists(webConfigFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(webConfigFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("entityFramework").Item(0);
            if (node == null)
                return false;
            XmlElement providersNode = doc.CreateElement("providers", node.NamespaceURI);
            XmlElement providerNode = doc.CreateElement("provider", node.NamespaceURI);
            providerNode.SetAttribute("invariantName", this._dbSetting.ProviderInvariantName);
            providerNode.SetAttribute("type", this._dbSetting.ProviderType);
            providersNode.AppendChild(providerNode);
            node.AppendChild(providersNode);
            doc.Save(webConfigFile);
            return true;
        }

        private bool addModelFileItemInCSPROJFile(IEnumerable<KeyValuePair<string, string>> modelFiles)
        {
            string CSPROJFileName = this.Path + "\\" + this.Name + "\\" + this.Name + ".csproj";
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
    }
}
