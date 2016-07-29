// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System.Data.Entity.Infrastructure;

    internal interface IContextGenerator
    {
        string Generate(DbModel model, string codeNamespace, string contextClassName, string connectionStringName);
    }
}