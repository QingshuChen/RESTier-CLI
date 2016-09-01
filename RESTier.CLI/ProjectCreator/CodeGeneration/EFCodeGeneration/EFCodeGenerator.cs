using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.RESTier.Cli.Database;
using Microsoft.Data.Entity.Design.VersioningFacade;
using Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb;
using Microsoft.RESTier.Cli.EFTools.EntityDesign;
using System.Collections;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.Common;
using System.Diagnostics;

namespace Microsoft.RESTier.Cli.ProjectCreator.CodeGeneration.EFCodeGeneration
{
    class EFCodeGenerator : ICodeGenerator
    {

        public IEnumerable<KeyValuePair<string, string>> generate(string connectionString, string projectName, string @namespace, DatabaseSetting dbSetting)
        {
            try
            {
                DatabaseManager dbManager = new DatabaseManager(connectionString, dbSetting);
                if (!dbManager.connect())
                {
                    return null;
                }
                var schemaFilterEntryBag = new SchemaFilterEntryBag();
                var databaseTables = new ArrayList();
                databaseTables = dbManager.GetDatabaseTables();
                if (databaseTables.Count != 0)
                {
                    for (var i = 0; i < databaseTables.Count; i++)
                    {
                        var tableItem = (Tuple<string, string, string>)(databaseTables[i]);
                        var item = new EntityStoreSchemaFilterEntry(tableItem.Item1,
                            tableItem.Item2, tableItem.Item3, EntityStoreSchemaFilterObjectTypes.Table,
                            EntityStoreSchemaFilterEffect.Allow);
                        schemaFilterEntryBag.IncludedTableEntries.Add(item);
                    }
                }
                var databaseViews = new ArrayList();
                databaseViews = dbManager.GetDatabaseViews();
                if (databaseViews.Count != 0)
                {
                    for (var i = 0; i < databaseViews.Count; i++)
                    {
                        var viewItem = (Tuple<string, string, string>)(databaseViews[i]);
                        var item = new EntityStoreSchemaFilterEntry(viewItem.Item1,
                            viewItem.Item2, viewItem.Item3, EntityStoreSchemaFilterObjectTypes.View,
                            EntityStoreSchemaFilterEffect.Allow);
                        schemaFilterEntryBag.IncludedViewEntries.Add(item);
                    }
                }


                var modelBuilderSettings = new ModelBuilderSettings();
                modelBuilderSettings._designTimeConnectionString = connectionString;
                modelBuilderSettings._designTimeProviderInvariantName =
                    dbSetting.ProviderInvariantName;
                modelBuilderSettings._runtimeProviderInvariantName =
                    dbSetting.ProviderInvariantName;
                modelBuilderSettings.UsePluralizationService = true;
                modelBuilderSettings.IncludeForeignKeysInModel = true;

                modelBuilderSettings.DatabaseObjectFilters =
                    schemaFilterEntryBag.CollapseAndOptimize(SchemaFilterPolicy.GetByValEdmxPolicy());
                modelBuilderSettings.ModelBuilderEngine = new CodeFirstModelBuilderEngine();
                // The latest EntityFramework version
                modelBuilderSettings.TargetSchemaVersion = new Version(3, 0, 0, 0);

                // Get the providerManifestTokern 
                IDbDependencyResolver resolver = Microsoft.Data.Entity.Design.VersioningFacade.DependencyResolver.Instance;
                var providerServices =
                    resolver.GetService<System.Data.Entity.Core.Common.DbProviderServices>(dbSetting.ProviderInvariantName);
                var factory = DbProviderFactories.GetFactory(dbSetting.ProviderInvariantName);
                var dbconnection = factory.CreateConnection();
                dbconnection.ConnectionString = connectionString;
                Debug.Assert(providerServices != null, "Trying to get unregistered provider.");
                modelBuilderSettings.ProviderManifestToken = providerServices.GetProviderManifestToken(dbconnection);

                // the function provided by EntityFramework to generate model from a database
                var mbe = modelBuilderSettings.ModelBuilderEngine;
                mbe.GenerateModel(modelBuilderSettings);

                // the function provided by EntityFramework to generate code from a model
                var generator = new CodeFirstModelGenerator();
                var result = generator.Generate(mbe.Model, @namespace + ".Models", projectName + "DbContext", projectName);
                string key = projectName + "DbContext.cs";
                if (dbSetting.DBType == DatabaseType.MYSQL)
                {
                    return result.Where(c => !c.Key.Equals(key)).Concat(
                    new[] { new KeyValuePair<string, string>(key, addMySqlNamespace(result.First(c => c.Key.Equals(key)).Value)) });
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private string addMySqlNamespace(string content)
        {
            string flag = "using System.Linq;";
            int index = content.IndexOf(flag) + flag.Length + 1;
            content = content.Substring(0, index) + "\tusing MySql.Data.Entity;\n" + "[DbConfigurationType(typeof(MySqlEFConfiguration))]\n" + content.Substring(index);
            return content;
        }
    }
}
