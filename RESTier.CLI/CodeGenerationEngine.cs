using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Diagnostics;
using Microsoft.Data.Entity.Design.VersioningFacade;
using Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb;
using Microsoft.RESTier.Cli.EFTools.EntityDesign;

namespace Microsoft.RESTier.Cli
{
    public class CodeGenerationEngine
    {
        private readonly string connectionString;

        private readonly string @namespace;

        private readonly string projectName;

        private readonly SQLServerDatabaseManager sqlManager;

        public CodeGenerationEngine(string connectionString, string projectName, string @namespace)
        {
            this.connectionString = connectionString;
            this.projectName = projectName;
            this.@namespace = @namespace;
            sqlManager = new SQLServerDatabaseManager(connectionString);
        }

        /// <summary>
        ///     Generate the mapping class for each table in the database
        /// </summary>
        /// <returns>
        ///     return the mapping class for each table in the database,
        ///     the key is the class file name and the value is the code for the class
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GenerateCode()
        {
            try
            {
                if (!sqlManager.connect())
                {
                    return null;
                }
                var schemaFilterEntryBag = new SchemaFilterEntryBag();
                var databaseTables = new ArrayList();
                databaseTables = sqlManager.GetDatabaseTables();
                if (databaseTables.Count != 0)
                {
                    var tableItem = (DatabaseTableOrView) (databaseTables[0]);
                    for (var i = 0; i < databaseTables.Count; i++)
                    {
                        tableItem = (DatabaseTableOrView) (databaseTables[i]);
                        var item = new EntityStoreSchemaFilterEntry(tableItem.CatalogName,
                            tableItem.SchemaName, tableItem.TableOrViewName, EntityStoreSchemaFilterObjectTypes.Table,
                            EntityStoreSchemaFilterEffect.Allow);
                        schemaFilterEntryBag.IncludedTableEntries.Add(item);
                    }
                }
                var databaseViews = new ArrayList();
                databaseViews = sqlManager.GetDatabaseViews();
                if (databaseViews.Count != 0)
                {
                    var viewItem = (DatabaseTableOrView) (databaseViews[0]);
                    for (var i = 0; i < databaseViews.Count; i++)
                    {
                        viewItem = (DatabaseTableOrView) (databaseViews[i]);
                        var item = new EntityStoreSchemaFilterEntry(viewItem.CatalogName,
                            viewItem.SchemaName, viewItem.TableOrViewName, EntityStoreSchemaFilterObjectTypes.View,
                            EntityStoreSchemaFilterEffect.Allow);
                        schemaFilterEntryBag.IncludedViewEntries.Add(item);
                    }
                }


                var modelBuilderSettings = new ModelBuilderSettings();
                modelBuilderSettings._designTimeConnectionString = connectionString;
                modelBuilderSettings._designTimeProviderInvariantName =
                    ConfigurationManager.AppSettings["ProviderInvariantName"];
                modelBuilderSettings._runtimeProviderInvariantName =
                    ConfigurationManager.AppSettings["ProviderInvariantName"];
                modelBuilderSettings.UsePluralizationService = true;
                modelBuilderSettings.IncludeForeignKeysInModel = true;

                modelBuilderSettings.DatabaseObjectFilters =
                    schemaFilterEntryBag.CollapseAndOptimize(SchemaFilterPolicy.GetByValEdmxPolicy());
                modelBuilderSettings.ModelBuilderEngine = new CodeFirstModelBuilderEngine();
                // The latest EntityFramework version
                modelBuilderSettings.TargetSchemaVersion = new Version(3, 0, 0, 0);

                // Get the providerManifestTokern 
                IDbDependencyResolver resolver = DependencyResolver.Instance;
                var providerServices =
                    resolver.GetService<System.Data.Entity.Core.Common.DbProviderServices>(ConfigurationManager.AppSettings["ProviderInvariantName"]);
                var factory = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["ProviderInvariantName"]);
                var dbconnection = factory.CreateConnection();
                dbconnection.ConnectionString = connectionString;
                Debug.Assert(providerServices != null, "Trying to get unregistered provider.");
                modelBuilderSettings.ProviderManifestToken = providerServices.GetProviderManifestToken(dbconnection);

                // the function provided by EntityFramework to generate model from a database
                var mbe = modelBuilderSettings.ModelBuilderEngine;
                mbe.GenerateModel(modelBuilderSettings);

                // the function provided by EntityFramework to generate code from a model
                var generator = new CodeFirstModelGenerator();
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