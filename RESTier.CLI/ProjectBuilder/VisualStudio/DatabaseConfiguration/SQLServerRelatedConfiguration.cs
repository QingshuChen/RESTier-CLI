using Microsoft.RESTier.Cli.Database;
using Microsoft.RESTier.Cli.ProjectBuilder.CodeGeneration;
using Microsoft.RESTier.Cli.ProjectBuilder.CodeGeneration.EFCodeGeneration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.RESTier.Cli.ProjectBuilder.VisualStudio.DatabaseConfiguration
{
    internal class SQLServerRelatedConfiguration : IDatabaseRelatedConfiguration
    {
        public string ConnectionString { get; set; }

        public IProjectBuilder ProjectBuilder { get; set; }


        public bool AddDatabaseConnectionString()
        {
            string webConfigFile = ProjectBuilder.Path + "\\" + ProjectBuilder.Name + @"\Web.config";
            if (!File.Exists(webConfigFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(webConfigFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("configuration").Item(0);
            if (node == null)
                return false;
            XmlElement connectionStringNode = doc.CreateElement("connectionStrings", node.NamespaceURI);
            XmlElement addNode = doc.CreateElement("add", node.NamespaceURI);
            addNode.SetAttribute("name", ProjectBuilder.Name);
            addNode.SetAttribute("connectionString", ConnectionString);
            addNode.SetAttribute("providerName", DatabaseSettingsFactory.Create("SQLServer").ProviderInvariantName);
            connectionStringNode.AppendChild(addNode);
            node.AppendChild(connectionStringNode);
            doc.Save(webConfigFile);
            return true;
        }

        public bool AddDatabaseModles()
        {
            ICodeGenerator codeGenerator = new EFCodeGenerator();
            var result = codeGenerator.generate(this.ConnectionString, ProjectBuilder.Name, ProjectBuilder.Namespace, DatabaseSettingsFactory.Create("SQLServer"));
            if (result == null)
                return false;
            return AddModleFile(result);
        }

        public bool AddDatabaseProvider()
        {
            string webConfigFile = ProjectBuilder.Path + "\\" + ProjectBuilder.Name + @"\Web.config";
            if (!File.Exists(webConfigFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(webConfigFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("entityFramework").Item(0);
            if (node == null)
                return false;
            XmlElement providersNode = doc.CreateElement("providers", node.NamespaceURI);
            XmlElement providerNode = doc.CreateElement("provider", node.NamespaceURI);
            var dbSetting = DatabaseSettingsFactory.Create("SQLServer");
            providerNode.SetAttribute("invariantName", dbSetting.ProviderInvariantName);
            providerNode.SetAttribute("type", dbSetting.ProviderType);
            providersNode.AppendChild(providerNode);
            node.AppendChild(providersNode);
            doc.Save(webConfigFile);
            return true;
        }

        public bool AddDatabaseRelatedCode()
        {
            return true;
        }

        public bool AddDatabaseRelatedPackages()
        {
            return true;
        }

        // To add files to the cs project, we need to update the .csproj file
        private bool AddModelFileItemInCSPROJFile(IEnumerable<KeyValuePair<string, string>> modelFiles)
        {
            string CSPROJFileName = ProjectBuilder.Path + "\\" + ProjectBuilder.Name + "\\" + ProjectBuilder.Name + ".csproj";
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
            string modelDirPath = ProjectBuilder.Path + "\\" + ProjectBuilder.Name + "\\Models\\";
            foreach (var file in modelFiles)
            {
                fs = File.Create(modelDirPath + file.Key);
                fs.Close();
                streamwrite = new StreamWriter(modelDirPath + file.Key);
                streamwrite.Write(file.Value);
                streamwrite.Close();
            }
            return AddModelFileItemInCSPROJFile(modelFiles);
        }
    }
}
