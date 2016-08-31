// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    /// <summary>
    /// Represents a model configuration to mark a string property as non-Unicode.
    /// </summary>
    public class NonUnicodeConfiguration : IFluentConfiguration
    {
        /// <inheritdoc />
        public virtual string GetMethodChain(CodeHelper code)
        {
            return ".IsUnicode(" + code.Literal(false) + ")";
        }
    }
}
