// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public abstract class ModelBuilderEngine
    {
        public DbModel Model { get; set; }

        // virutal for testing
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public virtual void GenerateModel(ModelBuilderSettings settings)
        {
           

            var generatingModelWatch = Stopwatch.StartNew();

            var errors = new List<EdmSchemaError>();

            try
            {
                var storeModelNamespace = GetStoreNamespace(settings);
                Model = GenerateModels(storeModelNamespace, settings, errors);

                ProcessModel(Model, storeModelNamespace, settings, errors);


            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                generatingModelWatch.Stop();
            }
        }

        // internal virtual to allow mocking
        internal virtual DbModel GenerateModels(string storeModelNamespace, ModelBuilderSettings settings, List<EdmSchemaError> errors)
        {
            return new ModelGenerator(settings, storeModelNamespace).GenerateModel(errors);
        }

        protected abstract void ProcessModel(
            DbModel model, string storeModelNamespace, ModelBuilderSettings settings,
            List<EdmSchemaError> errors);

        private static string GetStoreNamespace(ModelBuilderSettings settings)
        {
            return
                string.IsNullOrEmpty(settings.StorageNamespace)
                    ? String.Format(
                        CultureInfo.CurrentCulture,
                        "{0}.Store",
                        settings.ModelNamespace)
                    : settings.StorageNamespace;
        }

        private static string FormatMessage(string resourcestringName, params object[] args)
        {
            return
                String.Format(
                    CultureInfo.CurrentCulture,
                    resourcestringName,
                    args);
        }
    }
}
