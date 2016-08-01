// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.RESTier.Cli.EFTools.EntityDesign
{
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Diagnostics;
    using System.Linq;

    internal static class MultiplicityDiscoverer
    {
        public static MultiplicityConfiguration Discover(NavigationProperty navigationProperty, out bool isDefault)
        {
            Debug.Assert(navigationProperty != null, "navigationProperty is null.");

            var entityType = (EntityType)navigationProperty.DeclaringType;
            var otherEntityType = navigationProperty.ToEndMember.GetEntityType();
            var otherNavigationProperty = otherEntityType.NavigationProperties.First(
                p => p.ToEndMember == navigationProperty.FromEndMember);

            isDefault = (navigationProperty.FromEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many
                    || otherNavigationProperty.FromEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many)
                && !entityType.NavigationProperties.Where(p => p.ToEndMember.GetEntityType() == otherEntityType)
                    .MoreThan(1);

            return new MultiplicityConfiguration
                {
                    LeftEntityType = entityType,
                    LeftNavigationProperty = navigationProperty,
                    RightNavigationProperty = otherNavigationProperty
                };
        }
    }
}

