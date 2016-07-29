using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    class CodeFirstModelGenerator
    {
        public CodeFirstModelGenerator()
        {

        }

        // virtual for testing
        public virtual IEnumerable<KeyValuePair<string, string>> Generate(DbModel model, string codeNamespace, string contextClassName, string connectionStringName)
        {
            var extension = ".cs";

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
                throw ex;
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
                        throw ex;
                    }

                    yield return new KeyValuePair<string, string>(entityTypeFileName, entityTypeFileContents);
                }
            }
        }
    }
}
