# RESTier-CLI
*RESTier CLI Commands*

## Requirements
- [MSBuild](https://msdn.microsoft.com/en-us/library/dd393573.aspx) that supports C# 6.0, e.g., the one that comes with [Visual Studio 2015](https://www.visualstudio.com/en-us/products/vs-2015-product-editions.aspx).
- An [Entity Framework](http://www.asp.net/entity-framework) supported database.

## How to Build
1. Open a command prompt and go to the tools/EntityFramework directory. Then run the following command:  
        `BuildEFTools /t:RestorePackages`  
        `BuildEFTools /t:EnableSkipStrongNames`  
   These commands only need to be run one time for each machine and do not need to be re-run every time you build.  
2. Open the RESTier.CLI.sln and build the project.
