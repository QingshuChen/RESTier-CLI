// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System;
    using System.Activities;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using EnvDTE;
    using Microsoft.RESTier.Cli.EFTools.EntityDesign;
    using Microsoft.Data.Entity.Design.VersioningFacade.ReverseEngineerDb;
    using System.Collections.Generic;

    // <summary>
    //     Settings class used by ModelBuilderEngine
    // </summary>
    public class ModelBuilderSettings
    {
        #region Constructors

        public ModelBuilderSettings()
        {
        }

        #endregion Constructors

        #region Fields


        public string _designTimeConnectionString;
        private string _appConfigConnectionString;
        private string _appConfigConnectionPropertyName;
        public string _designTimeProviderInvariantName;
        public string _runtimeProviderInvariantName;
        private string _modelNamespace;
        private readonly Dictionary<string, Object> _extensionData = new Dictionary<string, Object>();
        private Version _targetSchemaVersion;

        #endregion Fields

        #region Properties


        internal string InitialCatalog { get; set; }

        // virtual for testing
        internal virtual string DesignTimeConnectionString
        {
            get { return _designTimeConnectionString; }
        }

        // virtual for testing
        internal virtual string AppConfigConnectionString
        {
            get { return _appConfigConnectionString; }
        }

        internal bool SaveConnectionStringInAppConfig { get; set; }

        internal string AppConfigConnectionPropertyName
        {
            get { return _appConfigConnectionPropertyName; }
            set { _appConfigConnectionPropertyName = value; }
        }

        public ICollection<EntityStoreSchemaFilterEntry> DatabaseObjectFilters { get; set; }

        internal string ModelNamespace
        {
            get
            {
                if (String.IsNullOrEmpty(_modelNamespace))
                {
                    return ModelConstants.DefaultModelNamespace;
                }
                else
                {
                    return _modelNamespace;
                }
            }

            set { _modelNamespace = value; }
        }

        internal string StorageNamespace { get; set; }

        internal string ModelEntityContainerName
        {
            get
            {
                if (!String.IsNullOrEmpty(_appConfigConnectionPropertyName))
                {
                    return _appConfigConnectionPropertyName;
                }
                else
                {
                    return ModelConstants.DefaultEntityContainerName;
                }
            }
        }

        internal string DdlFileName { get; set; }

        internal StringReader SsdlStringReader { get; set; }

        internal StringReader MslStringReader { get; set; }

        internal StringReader DdlStringReader { get; set; }

        internal WorkflowApplication WorkflowInstance { get; set; }

        public string ProviderManifestToken { get; set; }




        // this is only used by test code
        internal void SetInvariantNamesAndConnectionStrings(
            string runtimeInvariantName, string designTimeInvariantName, string connectionString, string appConfigConnectionString)
        {
            _runtimeProviderInvariantName = runtimeInvariantName;
            _designTimeProviderInvariantName = designTimeInvariantName;
            _appConfigConnectionString = appConfigConnectionString;
            _designTimeConnectionString = connectionString;
        }

        // virtual for testing
        internal virtual string RuntimeProviderInvariantName
        {
            get { return _runtimeProviderInvariantName; }
        }

        // virtual for testing
        internal virtual string DesignTimeProviderInvariantName
        {
            get { return _designTimeProviderInvariantName; }
        }

        internal TimeSpan LoadingDBMetatdataTime { get; set; }


        internal Dictionary<string, object> ExtensionData
        {
            get { return _extensionData; }
        }

        internal T GetExtensionDataValue<T>(string keyName)
        {
            object value;
            _extensionData.TryGetValue(keyName, out value);
            return (T)value;
        }

        public bool UsePluralizationService { get; set; }

        public ModelBuilderEngine ModelBuilderEngine { get; set; }

        public bool IncludeForeignKeysInModel { get; set; }

        internal bool HasExtensionChangedModel { get; set; }

        public Version TargetSchemaVersion
        {
            get { return _targetSchemaVersion; }
            set
            {
                Debug.Assert(EntityFrameworkVersion.IsValidVersion(value), "value is not a valid schema version.");

                _targetSchemaVersion = value;
            }
        }

        public bool UseLegacyProvider { get; set; }

        //  Path to the selected item (project or folder) that we are adding new items into
        public string NewItemFolder { get; set; }

        public Project Project { get; set; }

        public string ModelName { get; set; }

        // Path to the file containing model - note that the file may not exist yet (e.g. when reverse
        // engineering db we calculate the path at the begining but save the model when the wizard completes)
        public string ModelPath { get; set; }

        public string VsTemplatePath { get; set; }

        public IDictionary<string, string> ReplacementDictionary { get; set; }

        #endregion Properties
    }
}
