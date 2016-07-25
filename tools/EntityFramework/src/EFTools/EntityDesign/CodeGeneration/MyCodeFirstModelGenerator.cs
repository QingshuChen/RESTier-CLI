// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.Data.Entity.Design.CodeGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using EnvDTE;
    using Microsoft.Data.Entity.Design.Common;
    using Microsoft.Data.Entity.Design.VisualStudio;
    using Resources = Microsoft.Data.Entity.Design.VisualStudio.ModelWizard.Properties.Resources;

    public class MyCodeFirstModelGenerator
    {
        private readonly LangEnum _language;
        private readonly CodeGeneratorFactory _codeGeneratorFactory;

        public MyCodeFirstModelGenerator()
        {
           

            _codeGeneratorFactory = new CodeGeneratorFactory(null);
            _language = LangEnum.CSharp;
            Debug.Assert(_language != LangEnum.Unknown, "_language is Unknown.");
        }

        // virtual for testing
        public virtual IEnumerable<KeyValuePair<string, string>> Generate(DbModel model, string codeNamespace, string contextClassName, string connectionStringName)
        {
            var extension = _language == LangEnum.VisualBasic
                ? FileExtensions.VbExt
                : FileExtensions.CsExt;

            var contextFileName = contextClassName + extension;

            string contextFileContents;
            try
            {
                contextFileContents =
                    new DefaultCSharpContextGenerator()
                        .Generate(model, codeNamespace, contextClassName, connectionStringName);
            }
            catch (Exception ex)
            {
                throw new CodeFirstModelGenerationException(
                    string.Format(Resources.ErrorGeneratingCodeFirstModel, contextFileName),
                    ex);
            }

            yield return new KeyValuePair<string, string>(contextFileName, contextFileContents);

            if (model != null)
            {
                foreach (var entitySet in model.ConceptualModel.Container.EntitySets)
                {
                    var entityTypeGenerator = new DefaultCSharpEntityTypeGenerator();
                    var entityTypeFileName = entitySet.ElementType.Name + extension;

                    string entityTypeFileContents;
                    try
                    {
                        entityTypeFileContents = entityTypeGenerator.Generate(entitySet, model, codeNamespace);
                    }
                    catch (Exception ex)
                    {
                        throw new CodeFirstModelGenerationException(
                            string.Format(Resources.ErrorGeneratingCodeFirstModel, entityTypeFileName),
                            ex);
                    }

                    yield return new KeyValuePair<string, string>(entityTypeFileName, entityTypeFileContents);
                }
            }
        }
    }
}
