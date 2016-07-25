# RESTier-CLI
RESTier CLI Commands
How to build?
1. Open a command prompt and go to the tools/EntityFramework directory. Then run the following command:
    BuildEFTools /t:RestorePackages 
    BuildEFTools /t:EnableSkipStrongNames
   These commands only need to be run one time for each machine and do not need to be re-run every time you build.
2. Open the RESTier.CLI.sln and build the project.
