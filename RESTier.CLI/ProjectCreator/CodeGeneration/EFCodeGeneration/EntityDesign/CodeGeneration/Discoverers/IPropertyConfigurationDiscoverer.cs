// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;

    internal interface IPropertyConfigurationDiscoverer
    {
        IConfiguration Discover(EdmProperty property, DbModel model);
    }
}
