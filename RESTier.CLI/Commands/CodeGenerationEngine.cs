using System;
using Microsoft.Data.Entity.Design.CodeGeneration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using Microsoft.Data.Entity.Design.VersioningFacade;
using Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Engine;
using System.Data;
using Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common;
using System.Diagnostics;
using System.Data.Entity.Infrastructure.DependencyResolution;

namespace Microsoft.RESTier.Cli.Commands
{
    public class CodeGenerationEngine
    {
        private string connectionString;

        private Version maxVersion = new Version(3, 0, 0, 0);

        private string projectName;

        private SQLServerDatabaseManager sqlManager = null;

        private string @namespace;

        public CodeGenerationEngine (string connectionString, string projectName, string @namespace)
        {
            this.connectionString = connectionString;
            this.projectName = projectName;
            this.@namespace = @namespace;
            sqlManager = new SQLServerDatabaseManager(connectionString);
        }

        /// <summary>
        /// Generate the mapping class for each table in the database
        /// </summary>
        /// <returns>return the mapping class for each table in the database,
        /// the key is the class file name and the value is the code for the class</returns>
        public IEnumerable<KeyValuePair<string, string>> GenerateCode()
        {
            try
            {
                if(!sqlManager.connect())
                {
                    return null;
                }
                SchemaFilterEntryBag schemaFilterEntryBag = new Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Engine.SchemaFilterEntryBag();
                ArrayList databaseTables = new ArrayList();
                databaseTables = sqlManager.GetDatabaseTables();
                if (databaseTables.Count != 0)
                {
                    DatabaseTableOrView tableItem = (DatabaseTableOrView)(databaseTables[0]);
                    for (int i = 0; i < databaseTables.Count; i++)
                    {
                        tableItem = (DatabaseTableOrView)(databaseTables[i]);
                        EntityStoreSchemaFilterEntry item = new EntityStoreSchemaFilterEntry(tableItem.catalogName,
                            tableItem.schemaName, tableItem.tableOrViewName, EntityStoreSchemaFilterObjectTypes.Table,
                            EntityStoreSchemaFilterEffect.Allow);
                        schemaFilterEntryBag.IncludedTableEntries.Add(item);
                    }
                }
                ArrayList databaseViews = new ArrayList();
                databaseViews = sqlManager.GetDatabaseViews();
                if (databaseViews.Count != 0)
                {
                    DatabaseTableOrView viewItem = (DatabaseTableOrView)(databaseViews[0]);
                    for (int i = 0; i < databaseViews.Count; i++)
                    {
                        viewItem = (DatabaseTableOrView)(databaseViews[i]);
                        EntityStoreSchemaFilterEntry item = new EntityStoreSchemaFilterEntry(viewItem.catalogName,
                            viewItem.schemaName, viewItem.tableOrViewName, EntityStoreSchemaFilterObjectTypes.View,
                            EntityStoreSchemaFilterEffect.Allow);
                        schemaFilterEntryBag.IncludedViewEntries.Add(item);
                    }
                }


                ModelBuilderSettings modelBuilderSettings = new ModelBuilderSettings();
                modelBuilderSettings._designTimeConnectionString = connectionString;
                modelBuilderSettings._designTimeProviderInvariantName = ConfigurationManager.AppSettings["ProviderInvariantName"];
                modelBuilderSettings._runtimeProviderInvariantName = ConfigurationManager.AppSettings["ProviderInvariantName"];
                modelBuilderSettings.UsePluralizationService = true;
                modelBuilderSettings.IncludeForeignKeysInModel = true;

                modelBuilderSettings.DatabaseObjectFilters = schemaFilterEntryBag.CollapseAndOptimize(SchemaFilterPolicy.GetByValEdmxPolicy());
                modelBuilderSettings.ModelBuilderEngine = new MyCodeFirstModelBuilderEngine();
                // The latest EntityFramework version
                modelBuilderSettings.TargetSchemaVersion = new Version(3, 0, 0, 0);

                // Get the providerManifestTokern 
                IDbDependencyResolver resolver = DependencyResolver.Instance;
                // TODO: These should be using the value off the modelBuilderSettings, right?
                var providerServices = resolver.GetService<DbProviderServices>(ConfigurationManager.AppSettings["ProviderInvariantName"]);
                var factory = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["ProviderInvariantName"]);
                var dbconnection = factory.CreateConnection();
                dbconnection.ConnectionString = connectionString;
                Debug.Assert(providerServices != null, "Trying to get unregistered provider.");
                modelBuilderSettings.ProviderManifestToken = providerServices.GetProviderManifestToken(dbconnection);

                // the function provided by EntityFramework to generate model from a database
                var mbe = modelBuilderSettings.ModelBuilderEngine;
                mbe.GenerateModel(modelBuilderSettings);

                // the function provided by EntityFramework to generate code from a model
                var generator = new MyCodeFirstModelGenerator();
                return generator.Generate(mbe.Model, @namespace + ".Models", projectName + "DbContext", projectName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
