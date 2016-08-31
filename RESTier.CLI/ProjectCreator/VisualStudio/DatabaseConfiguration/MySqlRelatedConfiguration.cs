using Microsoft.RESTier.Cli.Database;
using Microsoft.RESTier.Cli.ProjectCreator.CodeGeneration;
using Microsoft.RESTier.Cli.ProjectCreator.CodeGeneration.EFCodeGeneration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.RESTier.Cli.ProjectCreator.VisualStudio.DatabaseConfiguration
{
    internal class MySqlRelatedConfiguration : IDatabaseRelatedConfiguration
    {
        public string ConnectionString { get; set; }

        public IProjectCreator ProjectCreator { get; set; }
        public bool AddDatabaseConnectionString()
        {
            string webConfigFile = ProjectCreator.Path + "\\" + ProjectCreator.Name + @"\Web.config";
            if (!File.Exists(webConfigFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(webConfigFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("configuration").Item(0);
            if (node == null)
                return false;
            XmlElement connectionStringNode = doc.CreateElement("connectionStrings", node.NamespaceURI);
            XmlElement addNode = doc.CreateElement("add", node.NamespaceURI);
            addNode.SetAttribute("name", ProjectCreator.Name);
            addNode.SetAttribute("connectionString", ConnectionString);
            addNode.SetAttribute("providerName", DatabaseSettingsFactory.Create("MySQL").ProviderInvariantName);
            connectionStringNode.AppendChild(addNode);
            node.AppendChild(connectionStringNode);
            doc.Save(webConfigFile);
            return true;
        }

        public bool AddDatabaseModles()
        {
            ICodeGenerator codeGenerator = new EFCodeGenerator();
            var result = codeGenerator.generate(this.ConnectionString, ProjectCreator.Name, ProjectCreator.Namespace, DatabaseSettingsFactory.Create("MySQL"));
            if (result == null)
                return false;
            return AddModleFile(result);
        }

        public bool AddDatabaseProvider()
        {
            string webConfigFile = ProjectCreator.Path + "\\" + ProjectCreator.Name + @"\Web.config";
            if (!File.Exists(webConfigFile))
                return false;
            XmlDocument doc = new XmlDocument();
            doc.Load(webConfigFile);
            XmlElement node = (XmlElement)doc.GetElementsByTagName("entityFramework").Item(0);
            if (node == null)
                return false;
            XmlElement providersNode = doc.CreateElement("providers", node.NamespaceURI);
            XmlElement providerNode = doc.CreateElement("provider", node.NamespaceURI);
            var dbSetting = DatabaseSettingsFactory.Create("MySQL");
            providerNode.SetAttribute("invariantName", dbSetting.ProviderInvariantName);
            providerNode.SetAttribute("type", dbSetting.ProviderType);
            providersNode.AppendChild(providerNode);
            node.AppendChild(providersNode);
            doc.Save(webConfigFile);
            return true;
        }

        public bool AddDatabaseRelatedCode()
        {
            String dbContextFile = ProjectCreator.Path + "\\" + ProjectCreator.Name + @"\Models\" + ProjectCreator.Name + "DbContext.cs";
            if (!File.Exists(dbContextFile))
            {
                return false;
            }
            StreamReader reader = new StreamReader(dbContextFile);
            String content = reader.ReadToEnd();
            string flag = "using System.Linq;";
            int index = content.IndexOf(flag) + flag.Length + 1;
            content = content.Substring(0, index) + "\tusing MySql.Data.Entity;\n" + "[DbConfigurationType(typeof(MySqlEFConfiguration))]\n" + content.Substring(index);
            reader.Close();
            StreamWriter writer = new StreamWriter(dbContextFile);
            writer.Write(content);
            writer.Close();
            return true;
        }

        private ArrayList getPackages()
        {
            ArrayList list = new ArrayList();
            list.Add(new Tuple<string, string, string>("MySql.Data", "7.0.3-DMR", "net452"));
            list.Add(new Tuple<string, string, string>("MySql.Data.Entity", "7.0.3-DMR", "net452"));
            return list;
        }

        private ArrayList getMysqlReference()
        {
            ArrayList list = new ArrayList();
            list.Add(new Tuple<string, string, string>(
                "MySql.Data, Version = 7.0.3.0, Culture = neutral, PublicKeyToken = c5687fc88969c44d, processorArchitecture = MSIL",
                @"..\packages\MySql.Data.7.0.3-DMR\lib\net45\MySql.Data.dll",
                "True"));
            list.Add(new Tuple<string, string, string>(
                "MySql.Data.Entity.EF6, Version=7.0.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d, processorArchitecture=MSIL",
                @"..\packages\MySql.Data.Entity.7.0.3-DMR\lib\net45\MySql.Data.Entity.EF6.dll",
                "True"));
            return list;
        }

        public bool AddDatabaseRelatedPackages()
        {
            // update package.config file
            string packageFile = ProjectCreator.Path + "\\" + ProjectCreator.Name + "\\packages.config";
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

            // update .csproj file
            string csprojFile = ProjectCreator.Path + "\\" + ProjectCreator.Name + "\\" + ProjectCreator.Name + ".csproj";
            doc.Load(csprojFile);
            node = (XmlElement)doc.GetElementsByTagName("ItemGroup").Item(0);
            foreach (Tuple<string, string, string> item in getMysqlReference())
            {
                XmlElement referenceNode = doc.CreateElement("Reference", node.NamespaceURI);
                referenceNode.SetAttribute("Include", item.Item1);
                XmlElement hintPathNode = doc.CreateElement("HintPath", node.NamespaceURI);
                hintPathNode.InnerText = item.Item2;
                referenceNode.AppendChild(hintPathNode);
                XmlElement privateNode = doc.CreateElement("Private", node.NamespaceURI);
                privateNode.InnerText = item.Item3;
                referenceNode.AppendChild(privateNode);
                node.AppendChild(referenceNode);
            }
            doc.Save(csprojFile);
            return true;
        }

        // To add files to the cs project, we need to update the .csproj file
        private bool AddModelFileItemInCSPROJFile(IEnumerable<KeyValuePair<string, string>> modelFiles)
        {
            string CSPROJFileName = ProjectCreator.Path + "\\" + ProjectCreator.Name + "\\" + ProjectCreator.Name + ".csproj";
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
            string modelDirPath = ProjectCreator.Path + "\\" + ProjectCreator.Name + "\\Models\\";
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
