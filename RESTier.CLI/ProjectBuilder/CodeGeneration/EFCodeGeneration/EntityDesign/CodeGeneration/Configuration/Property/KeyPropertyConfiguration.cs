// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System.Diagnostics;

    /// <summary>
    /// Represents a model configuration to include a property as part of the entity's key.
    /// </summary>
    public class KeyPropertyConfiguration : IAttributeConfiguration
    {
        /// <inheritdoc />
        public virtual string GetAttributeBody(CodeHelper code)
        {
            Debug.Assert(code != null, "code is null.");

            return "Key";
        }
    }
}
